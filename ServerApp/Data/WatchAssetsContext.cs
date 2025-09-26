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
                // Heavy Machinery
                new Asset { Id = 1, AssetName = "Excavator-XC100", AssetType = "Excavator", SerialNumber = "XC100-001", Location = "Site-A", Status = "Operational" },
                new Asset { Id = 2, AssetName = "Bulldozer-BD200", AssetType = "Bulldozer", SerialNumber = "BD200-002", Location = "Site-B", Status = "Maintenance" },
                new Asset { Id = 3, AssetName = "Loader-LD300", AssetType = "Wheel Loader", SerialNumber = "LD300-003", Location = "Site-C", Status = "Operational" },
                new Asset { Id = 4, AssetName = "Crane-CR400", AssetType = "Mobile Crane", SerialNumber = "CR400-004", Location = "Site-D", Status = "Operational" },
                new Asset { Id = 5, AssetName = "Backhoe-BH500", AssetType = "Backhoe Loader", SerialNumber = "BH500-005", Location = "Site-A", Status = "Under Repair" },
                new Asset { Id = 6, AssetName = "Grader-GR600", AssetType = "Motor Grader", SerialNumber = "GR600-006", Location = "Site-E", Status = "Operational" },
                new Asset { Id = 7, AssetName = "Compactor-CP700", AssetType = "Vibratory Roller", SerialNumber = "CP700-007", Location = "Site-B", Status = "Operational" },
                new Asset { Id = 8, AssetName = "Skid Steer-SS800", AssetType = "Skid Steer Loader", SerialNumber = "SS800-008", Location = "Site-C", Status = "Maintenance" },
                
                // Transportation
                new Asset { Id = 9, AssetName = "Truck-TK900", AssetType = "Dump Truck", SerialNumber = "TK900-009", Location = "Site-D", Status = "Operational" },
                new Asset { Id = 10, AssetName = "Trailer-TR1000", AssetType = "Flatbed Trailer", SerialNumber = "TR1000-010", Location = "Site-A", Status = "Operational" },
                
                // Generators & Power
                new Asset { Id = 11, AssetName = "Generator-GN1100", AssetType = "Diesel Generator", SerialNumber = "GN1100-011", Location = "Site-E", Status = "Operational" },
                new Asset { Id = 12, AssetName = "Compressor-CM1200", AssetType = "Air Compressor", SerialNumber = "CM1200-012", Location = "Site-B", Status = "Maintenance" },
                
                // Specialized Equipment
                new Asset { Id = 13, AssetName = "Drill Rig-DR1300", AssetType = "Rotary Drill", SerialNumber = "DR1300-013", Location = "Site-C", Status = "Operational" },
                new Asset { Id = 14, AssetName = "Pump-PMP1400", AssetType = "Water Pump", SerialNumber = "PMP1400-014", Location = "Site-D", Status = "Operational" },
                new Asset { Id = 15, AssetName = "Sweeper-SW1500", AssetType = "Street Sweeper", SerialNumber = "SW1500-015", Location = "Site-A", Status = "Operational" }
            );

            modelBuilder.Entity<AssetHealth>().HasData(
                // Heavy Machinery Health
                new AssetHealth { Id = 1, AssetId = 1, Temperature = 75.5, Pressure = 120.3, Vibration = 2.1, LastCheck = DateTime.Now.AddDays(-1), HealthScore = 85 },
                new AssetHealth { Id = 2, AssetId = 2, Temperature = 80.2, Pressure = 115.7, Vibration = 3.5, LastCheck = DateTime.Now.AddDays(-2), HealthScore = 70 },
                new AssetHealth { Id = 3, AssetId = 3, Temperature = 68.9, Pressure = 125.1, Vibration = 1.8, LastCheck = DateTime.Now.AddDays(-1), HealthScore = 92 },
                new AssetHealth { Id = 4, AssetId = 4, Temperature = 82.1, Pressure = 130.5, Vibration = 4.2, LastCheck = DateTime.Now.AddDays(-3), HealthScore = 65 },
                new AssetHealth { Id = 5, AssetId = 5, Temperature = 78.3, Pressure = 118.9, Vibration = 2.8, LastCheck = DateTime.Now.AddDays(-1), HealthScore = 78 },
                new AssetHealth { Id = 6, AssetId = 6, Temperature = 71.4, Pressure = 122.6, Vibration = 1.9, LastCheck = DateTime.Now.AddDays(-2), HealthScore = 88 },
                new AssetHealth { Id = 7, AssetId = 7, Temperature = 76.7, Pressure = 119.2, Vibration = 2.3, LastCheck = DateTime.Now.AddDays(-1), HealthScore = 83 },
                new AssetHealth { Id = 8, AssetId = 8, Temperature = 85.9, Pressure = 113.8, Vibration = 5.1, LastCheck = DateTime.Now.AddDays(-4), HealthScore = 55 },
                
                // Transportation Health
                new AssetHealth { Id = 9, AssetId = 9, Temperature = 90.2, Pressure = 85.4, Vibration = 3.2, LastCheck = DateTime.Now.AddDays(-1), HealthScore = 72 },
                new AssetHealth { Id = 10, AssetId = 10, Temperature = 65.1, Pressure = 32.7, Vibration = 1.5, LastCheck = DateTime.Now.AddDays(-2), HealthScore = 95 },
                
                // Generators & Power Health
                new AssetHealth { Id = 11, AssetId = 11, Temperature = 88.5, Pressure = 45.3, Vibration = 2.7, LastCheck = DateTime.Now.AddDays(-1), HealthScore = 76 },
                new AssetHealth { Id = 12, AssetId = 12, Temperature = 92.8, Pressure = 140.2, Vibration = 6.8, LastCheck = DateTime.Now.AddDays(-5), HealthScore = 45 },
                
                // Specialized Equipment Health
                new AssetHealth { Id = 13, AssetId = 13, Temperature = 79.6, Pressure = 155.7, Vibration = 3.9, LastCheck = DateTime.Now.AddDays(-1), HealthScore = 68 },
                new AssetHealth { Id = 14, AssetId = 14, Temperature = 69.3, Pressure = 88.9, Vibration = 1.7, LastCheck = DateTime.Now.AddDays(-2), HealthScore = 90 },
                new AssetHealth { Id = 15, AssetId = 15, Temperature = 73.8, Pressure = 42.1, Vibration = 2.4, LastCheck = DateTime.Now.AddDays(-1), HealthScore = 81 }
            );
        }
    }
}