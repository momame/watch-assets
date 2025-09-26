using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using watch_assets.Data;
using watch_assets.Models;

namespace watch_assets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetSearchController : ControllerBase
    {
        private readonly WatchAssetsContext _context;

        public AssetSearchController(WatchAssetsContext context)
        {
            _context = context;
        }

        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<Asset>>> SearchAssets([FromBody] AssetSearch searchParams)
        {
            var query = _context.Assets.AsQueryable();

            if (!string.IsNullOrEmpty(searchParams.Query))
            {
                query = query.Where(a => 
                    a.AssetName.Contains(searchParams.Query) || 
                    a.SerialNumber.Contains(searchParams.Query) ||
                    a.Location.Contains(searchParams.Query));
            }

            if (!string.IsNullOrEmpty(searchParams.Location))
            {
                query = query.Where(a => a.Location.Contains(searchParams.Location));
            }

            if (!string.IsNullOrEmpty(searchParams.AssetType))
            {
                query = query.Where(a => a.AssetType.Contains(searchParams.AssetType));
            }

            if (!string.IsNullOrEmpty(searchParams.Status))
            {
                query = query.Where(a => a.Status.Contains(searchParams.Status));
            }

            var assets = await query.ToListAsync();
            return Ok(assets);
        }

        [HttpGet("health")]
        public async Task<ActionResult<IEnumerable<AssetHealth>>> GetAssetsWithHealth([FromQuery] int minHealthScore = 0)
        {
            var healths = await _context.AssetHealths
                .Where(h => h.HealthScore >= minHealthScore)
                .ToListAsync();

            return Ok(healths);
        }

        [HttpGet("health-summary")]
        public async Task<ActionResult<object>> GetHealthSummary()
        {
            var totalAssets = await _context.Assets.CountAsync();
            var operationalAssets = await _context.Assets.CountAsync(a => a.Status == "Operational");
            var maintenanceAssets = await _context.Assets.CountAsync(a => a.Status == "Maintenance");
            var avgHealthScore = await _context.AssetHealths.AverageAsync(h => h.HealthScore);

            var summary = new
            {
                TotalAssets = totalAssets,
                OperationalAssets = operationalAssets,
                MaintenanceAssets = maintenanceAssets,
                AverageHealthScore = Math.Round(avgHealthScore ?? 0, 2)
            };

            return Ok(summary);
        }
    }
}