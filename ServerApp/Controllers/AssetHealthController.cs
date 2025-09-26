using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using watch_assets.Data;
using watch_assets.Models;

namespace watch_assets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetHealthController : ControllerBase
    {
        private readonly WatchAssetsContext _context;

        public AssetHealthController(WatchAssetsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetHealth>>> GetAssetHealths()
        {
            return await _context.AssetHealths.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetHealth>> GetAssetHealth(int id)
        {
            var health = await _context.AssetHealths.FindAsync(id);

            if (health == null)
            {
                return NotFound();
            }

            return health;
        }

        [HttpGet("asset/{assetId}")]
        public async Task<ActionResult<AssetHealth>> GetAssetHealthByAssetId(int assetId)
        {
            var health = await _context.AssetHealths
                .FirstOrDefaultAsync(h => h.AssetId == assetId);

            if (health == null)
            {
                return NotFound();
            }

            return health;
        }
    }
}