using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using NextHoliday.Domain.Entities;
using NextHoliday.Domain.Entities.History;
using System.Reflection;
using System.Text.Json;

namespace NextHoliday.Infrastructure.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentityUser>(options)
    {
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Destination> Destinations => Set<Destination>();
        public DbSet<ClimateHistory> ClimateHistories => Set<ClimateHistory>();
        public DbSet<PriceHistory> PriceHistories => Set<PriceHistory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.Code);
                entity.Property(c => c.Code).HasMaxLength(2).IsFixedLength();
                entity.Property(c => c.Name).HasMaxLength(100).IsRequired();
                entity.Property(c => c.Currency).HasMaxLength(3).IsRequired();
                entity.Property(c => c.Language).HasMaxLength(50).IsRequired();
                entity.Property(c => c.Capital).HasMaxLength(100).IsRequired();
                entity.Property(c => c.Continent).HasConversion<int>();
                entity.Property(c => c.RequiresVisa).IsRequired();
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.City).HasMaxLength(50).IsRequired();
                entity.Property(d => d.Description).HasMaxLength(500);
                entity.Property(d => d.Latitude).HasColumnType("float");
                entity.Property(d => d.Longitude).HasColumnType("float");

                // Store the HistoricalMonthlyMinTemps and HistoricalMonthlyMaxTemps as JSON strings in the db
                entity.Property(d => d.HistoricalMonthlyMinTemps).HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<double[]>(v, (JsonSerializerOptions?)null) ?? new double[12]
                ).Metadata.SetValueComparer(doubleArrayComparer);

                entity.Property(d => d.HistoricalMonthlyMaxTemps).HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<double[]>(v, (JsonSerializerOptions?)null) ?? new double[12]
                ).Metadata.SetValueComparer(doubleArrayComparer);

                // One country to many destinations
                entity.HasOne(d => d.Country)
                      .WithMany(c => c.Destinations)
                      .HasForeignKey(d => d.CountryCode)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ClimateHistory>(entity =>
            {
                entity.HasKey(ch => ch.Id).IsClustered(false);

                entity.HasIndex(ch => ch.Date).IsClustered(true);

                entity.Property(ch => ch.Date).IsRequired();
                entity.Property(ch => ch.WeatherCondition).HasMaxLength(50);

                entity.Property(ch => ch.MinTemperature).HasColumnType("float");
                entity.Property(ch => ch.MaxTemperature).HasColumnType("float");
                entity.Property(ch => ch.RainProbability).HasColumnType("float");

                // One destination to many climate histories
                entity.HasOne(ch => ch.Destination)
                      .WithMany(d => d.ClimateHistories)
                      .HasForeignKey(ch => ch.DestinationId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PriceHistory>(entity =>
            {
                entity.HasKey(ph => ph.Id);
                entity.Property(ph => ph.EstimatedFlightPrice).HasColumnType("decimal(18,2)");
                entity.Property(ph => ph.EstimatedHotelPricePerNight).HasColumnType("decimal(18,2)");

                // One destination to many price histories
                entity.HasOne(ph => ph.Destination)
                      .WithMany(d => d.PriceHistories)
                      .HasForeignKey(ph => ph.DestinationId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            PopulateCountries(modelBuilder);
            PopulateDestinations(modelBuilder);
        }

        private void PopulateCountries(ModelBuilder modelBuilder)
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(assemblyPath!, "Persistence", "countries.json");

            if (File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);
                var countries = JsonSerializer.Deserialize<List<Country>>(jsonString);

                if (countries != null)
                    modelBuilder.Entity<Country>().HasData(countries);

            } else Console.WriteLine("Failed to populate countries: countries.json file not found.");
        }
        private void PopulateDestinations(ModelBuilder modelBuilder)
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(assemblyPath!, "Persistence", "destinations.json");

            if (File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);
                var destinations = JsonSerializer.Deserialize<List<Destination>>(jsonString);

                if (destinations != null)
                    modelBuilder.Entity<Destination>().HasData(destinations);

            } else Console.WriteLine("Failed to populate destinations: destinations.json file not found.");
        }

        public async Task PromoteUserToAdminAsync(IServiceProvider services, string targetEmail)
        {
            using var scope = services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            const string adminRole = "Admin";

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
                Console.WriteLine($"[ADMIN] Role '{adminRole}' created with success.");
            }

            var user = await userManager.FindByEmailAsync(targetEmail);

            if (user != null)
            {
                if (!await userManager.IsInRoleAsync(user, adminRole))
                {
                    var result = await userManager.AddToRoleAsync(user, adminRole);

                    if (result.Succeeded)
                    {
                        Console.WriteLine($"[ADMIN] SUCCESS: Account '{targetEmail}' has been promoted to Admin!");
                    }
                    else
                    {
                        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                        Console.WriteLine($"[ADMIN] ERROR while promoting: {errors}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"[ADMIN] WARNING: Email '{targetEmail}' not found.");
            }
        }

        // COMPARERS
        private readonly ValueComparer doubleArrayComparer = new ValueComparer<double[]>(
            (c1, c2) => c1 != null && c2 != null && c1.SequenceEqual(c2), // Compare arrays for equality
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Combine hash codes for change tracking
            c => c.ToArray() // Snapshot for change tracking
        );
    }
}
