using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Domain.Entities;
using NextHoliday.Domain.Entities.History;
using NextHoliday.Domain.Enums;
using System.Reflection;
using System.Text.Json;

namespace NextHoliday.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

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

                // One country to many destinations
                entity.HasOne(d => d.Country)
                      .WithMany(c => c.Destinations)
                      .HasForeignKey(d => d.CountryCode)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ClimateHistory>(entity =>
            {
                entity.HasKey(ch => ch.Id);
                entity.Property(ch => ch.WeatherCondition).HasMaxLength(50);

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
    }
}
