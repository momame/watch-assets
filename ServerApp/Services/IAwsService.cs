namespace watch_assets.Services
{
    public interface IAwsService
    {
        Task<string> UploadAssetImageAsync(Stream fileStream, string fileName);
        Task<byte[]> DownloadAssetImageAsync(string fileName);
        Task<bool> DeleteAssetImageAsync(string fileName);
        Task<string> StoreAssetDataAsync(string assetId, object data);
    }
}