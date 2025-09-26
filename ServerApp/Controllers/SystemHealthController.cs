using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using watch_assets.Data;
using watch_assets.Services;

namespace watch_assets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemHealthController : ControllerBase
    {
        private readonly WatchAssetsContext _context;
        private readonly IAzureService _azureService;
        private readonly ILogger<SystemHealthController> _logger;

        public SystemHealthController(WatchAssetsContext context, IAzureService azureService, ILogger<SystemHealthController> logger)
        {
            _context = context;
            _azureService = azureService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetHealth()
        {
            var dbStatus = "Unknown";
            var apiStatus = "Healthy";
            var memoryUsage = GC.GetTotalMemory(false) / (1024 * 1024); // MB
            
            try
            {
                // Test database connectivity
                await _context.Assets.Take(1).ToListAsync();
                dbStatus = "Connected";
            }
            catch
            {
                dbStatus = "Disconnected";
                apiStatus = "Degraded";
            }

            var healthReport = new
            {
                Status = apiStatus,
                Timestamp = DateTime.UtcNow,
                Uptime = "Running",
                Dependencies = new
                {
                    Database = dbStatus,
                    MemoryUsageMB = memoryUsage,
                    ActiveConnections = 1 // Simplified
                },
                Performance = new
                {
                    ResponseTime = "Fast",
                    Throughput = "Normal"
                }
            };

            // Store health report to Azure for monitoring
            await _azureService.StoreAssetDataAsync($"health-{DateTime.UtcNow:yyyy-MM-dd-HH-mm}", healthReport);

            var statusCode = apiStatus == "Healthy" ? 200 : 503;
            return StatusCode(statusCode, healthReport);
        }
    }
}