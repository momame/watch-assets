using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using watch_assets.Data;
using watch_assets.Models;
using watch_assets.Services;

namespace watch_assets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly WatchAssetsContext _context;
        private readonly ILogger<AssetsController> _logger;
        private readonly IAzureService _azureService;

        public AssetsController(WatchAssetsContext context, ILogger<AssetsController> logger, IAzureService azureService)
        {
            _context = context;
            _logger = logger;
            _azureService = azureService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
        {
            var stopwatch = Stopwatch.StartNew();
            var assets = await _context.Assets.ToListAsync();
            stopwatch.Stop();
            
            _logger.LogInformation($"Retrieved {assets.Count} assets in {stopwatch.ElapsedMilliseconds}ms");
            
            return assets;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(int id)
        {
            var stopwatch = Stopwatch.StartNew();
            var asset = await _context.Assets.FindAsync(id);
            stopwatch.Stop();
            
            if (asset == null)
            {
                _logger.LogWarning($"Attempted to access non-existent asset ID: {id}");
                return NotFound();
            }
            
            _logger.LogInformation($"Retrieved asset {id} in {stopwatch.ElapsedMilliseconds}ms");
            return asset;
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Created new asset: {asset.AssetName}");
            return CreatedAtAction(nameof(GetAsset), new { id = asset.Id }, asset);
        }
    }
}