using Amazon.S3;
using Amazon.S3.Model;
using System.Text.Json;

namespace watch_assets.Services
{
    public class AwsService : IAwsService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public AwsService(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:BucketName"] ?? "watch-assets-bucket";
        }

        public async Task<string> UploadAssetImageAsync(Stream fileStream, string fileName)
        {
            var request = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = $"assets/{fileName}",
                InputStream = fileStream,
                ContentType = GetContentType(fileName)
            };

            var response = await _s3Client.PutObjectAsync(request);
            return $"https://{_bucketName}.s3.amazonaws.com/{request.Key}";
        }

        public async Task<byte[]> DownloadAssetImageAsync(string fileName)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = $"assets/{fileName}"
            };

            var response = await _s3Client.GetObjectAsync(request);
            
            using var memoryStream = new MemoryStream();
            await response.ResponseStream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public async Task<bool> DeleteAssetImageAsync(string fileName)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = $"assets/{fileName}"
            };

            var response = await _s3Client.DeleteObjectAsync(request);
            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<string> StoreAssetDataAsync(string assetId, object data)
        {
            var json = JsonSerializer.Serialize(data);
            var request = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = $"asset-data/{assetId}.json",
                ContentBody = json
            };

            var response = await _s3Client.PutObjectAsync(request);
            return $"https://{_bucketName}.s3.amazonaws.com/{request.Key}";
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