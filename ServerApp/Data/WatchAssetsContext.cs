using Microsoft.EntityFrameworkCore;
using watch_assets.Models;

namespace watch_assets.Data
{
    public class WatchAssetsContext : DbContext
    {
        public WatchAssetsContext(DbContextOptions<WatchAssetsContext> options) : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetHealth> AssetHealths { get; set; }
        public DbSet<AssetSearch> AssetSearches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>().HasData(
                new Asset { Id = 1, AssetName = "Excavator-XC100", AssetType = "Heavy Machinery", SerialNumber = "XC100-001", Location = "Site-A", Status = "Operational" },
                new Asset { Id = 2, AssetName = "Bulldozer-BD200", AssetType = "Heavy Machinery", SerialNumber = "BD200-002", Location = "Site-B", Status = "Maintenance" },
                new Asset { Id = 3, AssetName = "Loader-LD300", AssetType = "Heavy Machinery", SerialNumber = "LD300-003", Location = "Site-C", Status = "Operational" }
            );

            modelBuilder.Entity<AssetHealth>().HasData(
                new AssetHealth { Id = 1, AssetId = 1, Temperature = 75.5, Pressure = 120.3, Vibration = 2.1, LastCheck = DateTime.Now.AddDays(-1), HealthScore = 85 },
                new AssetHealth { Id = 2, AssetId = 2, Temperature = 80.2, Pressure = 115.7, Vibration = 3.5, LastCheck = DateTime.Now.AddDays(-2), HealthScore = 70 },
                new AssetHealth { Id = 3, AssetId = 3, Temperature = 68.9, Pressure = 125.1, Vibration = 1.8, LastCheck = DateTime.Now.AddDays(-1), HealthScore = 92 }
            );
        }
    }
}