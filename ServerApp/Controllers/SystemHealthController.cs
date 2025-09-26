using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace watch_assets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemHealthController : ControllerBase
    {
        private readonly WatchAssetsContext _context;

        public SystemHealthController(WatchAssetsContext context)
        {
            _context = context;
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

            var statusCode = apiStatus == "Healthy" ? 200 : 503;
            return StatusCode(statusCode, healthReport);
        }
    }
}