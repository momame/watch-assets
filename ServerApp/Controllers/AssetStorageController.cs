using Microsoft.AspNetCore.Mvc;
using watch_assets.Services;

namespace watch_assets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetStorageController : ControllerBase
    {
        private readonly IAzureService _azureService;
        private readonly ILogger<AssetStorageController> _logger;

        public AssetStorageController(IAzureService azureService, ILogger<AssetStorageController> logger)
        {
            _azureService = azureService;
            _logger = logger;
        }

        [HttpPost("upload")]
        public async Task<ActionResult<string>> UploadAssetImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is required");
            }

            using var stream = file.OpenReadStream();
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            
            try
            {
                var url = await _azureService.UploadAssetImageAsync(stream, fileName);
                _logger.LogInformation($"Asset image uploaded: {fileName}");
                
                return Ok(new { 
                    FileName = fileName, 
                    Url = url,
                    Size = file.Length,
                    ContentType = file.ContentType
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to upload asset image: {fileName}");
                return StatusCode(500, "Failed to upload file");
            }
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> DownloadAssetImage(string fileName)
        {
            try
            {
                var fileData = await _azureService.DownloadAssetImageAsync(fileName);
                var contentType = GetContentType(fileName);
                
                _logger.LogInformation($"Asset image downloaded: {fileName}");
                return File(fileData, contentType, fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to download asset image: {fileName}");
                return NotFound("File not found");
            }
        }

        [HttpDelete("delete/{fileName}")]
        public async Task<ActionResult<bool>> DeleteAssetImage(string fileName)
        {
            try
            {
                var result = await _azureService.DeleteAssetImageAsync(fileName);
                _logger.LogInformation($"Asset image deleted: {fileName}, Success: {result}");
                
                return Ok(new { Success = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete asset image: {fileName}");
                return StatusCode(500, "Failed to delete file");
            }
        }

        [HttpPost("store-data/{assetId}")]
        public async Task<ActionResult<string>> StoreAssetData(string assetId, [FromBody] object data)
        {
            try
            {
                var url = await _azureService.StoreAssetDataAsync(assetId, data);
                _logger.LogInformation($"Asset data stored for asset: {assetId}");
                
                return Ok(new { 
                    AssetId = assetId, 
                    StorageUrl = url 
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to store asset data for asset: {assetId}");
                return StatusCode(500, "Failed to store data");
            }
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