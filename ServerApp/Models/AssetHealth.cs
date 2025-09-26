namespace watch_assets.Models
{
    public class AssetHealth
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double Vibration { get; set; }
        public DateTime LastCheck { get; set; }
        public int HealthScore { get; set; }
    }
}