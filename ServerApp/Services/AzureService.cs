using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Text.Json;

namespace watch_assets.Services
{
    public class AzureService : IAzureService
    {
        private readonly BlobContainerClient _containerClient;
        private readonly string _containerName;

        public AzureService(IConfiguration configuration)
        {
            var connectionString = configuration["Azure:StorageConnectionString"] ?? 
                                 "UseDevelopmentStorage=true"; // For local development
            _containerName = configuration["Azure:ContainerName"] ?? "watch-assets-container";
            
            var blobServiceClient = new BlobServiceClient(connectionString);
            _containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            
            // Create container if it doesn't exist
            _containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob).Wait();
        }

        public async Task<string> UploadAssetImageAsync(Stream fileStream, string fileName)
        {
            var blobClient = _containerClient.GetBlobClient($"assets/{fileName}");
            
            var options = new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = GetContentType(fileName)
                }
            };

            await blobClient.UploadAsync(fileStream, options);
            return blobClient.Uri.ToString();
        }

        public async Task<byte[]> DownloadAssetImageAsync(string fileName)
        {
            var blobClient = _containerClient.GetBlobClient($"assets/{fileName}");
            
            var response = await blobClient.DownloadAsync();
            using var memoryStream = new MemoryStream();
            await response.Value.Content.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public async Task<bool> DeleteAssetImageAsync(string fileName)
        {
            var blobClient = _containerClient.GetBlobClient($"assets/{fileName}");
            var response = await blobClient.DeleteIfExistsAsync();
            return response.Value;
        }

        public async Task<string> StoreAssetDataAsync(string assetId, object data)
        {
            var json = JsonSerializer.Serialize(data);
            var blobClient = _containerClient.GetBlobClient($"asset-data/{assetId}.json");
            
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            await blobClient.UploadAsync(stream, true);
            
            return blobClient.Uri.ToString();
        }

        private string GetContentType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };
        }
    }
}