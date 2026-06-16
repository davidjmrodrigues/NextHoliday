using Microsoft.EntityFrameworkCore;
using NextHoliday.Domain.Entities;
using NextHoliday.Domain.Entities.History;
using NextHoliday.Domain.Enums;

namespace NextHoliday.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
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
                entity.Property(c => c.Continent).HasConversion<int>();
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.City).HasMaxLength(50).IsRequired();

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

            SeedData(modelBuilder);
        }
        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Code = "PT", Name = "Portugal", Continent = Continent.Europe },
                new Country { Code = "ES", Name = "Spain", Continent = Continent.Europe },
                new Country { Code = "FR", Name = "France", Continent = Continent.Europe },
                new Country { Code = "IT", Name = "Italy", Continent = Continent.Europe },
                new Country { Code = "US", Name = "United States", Continent = Continent.NorthAmerica },
                new Country { Code = "JP", Name = "Japan", Continent = Continent.Asia },
                new Country { Code = "CN", Name = "China", Continent = Continent.Asia },
                new Country { Code = "BR", Name = "Brazil", Continent = Continent.SouthAmerica },
                new Country { Code = "EG", Name = "Egypt", Continent = Continent.Africa },
                new Country { Code = "AU", Name = "Australia", Continent = Continent.Oceania }
            );
        }
    }
}
