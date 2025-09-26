namespace watch_assets.Models
{
    public class AssetSearch
    {
        public string Query { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string AssetType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int MinHealthScore { get; set; } = 0;
    }
}