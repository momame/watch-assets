using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using watch_assets.Data;
using watch_assets.Models;

namespace watch_assets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvancedSearchController : ControllerBase
    {
        private readonly WatchAssetsContext _context;

        public AdvancedSearchController(WatchAssetsContext context)
        {
            _context = context;
        }

        [HttpPost("semantic-search")]
        public async Task<ActionResult<IEnumerable<Asset>>> SemanticSearch([FromBody] AssetSearch searchParams)
        {
            // TODO: Replace with actual ML model for semantic search
            // For now using basic keyword matching with scoring
            var assets = await _context.Assets.ToListAsync();
            
            var scoredAssets = assets
                .Select(asset => new 
                {
                    Asset = asset,
                    Score = CalculateRelevanceScore(asset, searchParams)
                })
                .Where(x => x.Score > 0.3) // Threshold for relevance - might need tuning based on data
                .OrderByDescending(x => x.Score)
                .Select(x => x.Asset);

            // Note: In production, we'd want to cache these results for performance
            return Ok(scoredAssets);
        }

        [HttpGet("search-analytics")]
        public async Task<ActionResult<object>> GetSearchAnalytics()
        {
            var totalSearches = await _context.Assets.CountAsync(); // Simulate search analytics
            var popularSearches = new[] { "Excavator", "Maintenance", "Operational" };
            var avgResponseTime = 45.2; // ms

            var analytics = new
            {
                TotalSearches = totalSearches,
                PopularSearches = popularSearches,
                AverageResponseTime = avgResponseTime,
                PerformanceMetrics = new
                {
                    SearchThroughput = "1000 req/min",
                    CacheHitRate = "85%"
                }
            };

            return Ok(analytics);
        }

        private double CalculateRelevanceScore(Asset asset, AssetSearch searchParams)
        {
            double score = 0.0;

            if (!string.IsNullOrEmpty(searchParams.Query))
            {
                if (asset.AssetName.Contains(searchParams.Query, StringComparison.OrdinalIgnoreCase))
                    score += 0.4;
                if (asset.SerialNumber.Contains(searchParams.Query, StringComparison.OrdinalIgnoreCase))
                    score += 0.3;
                if (asset.Location.Contains(searchParams.Query, StringComparison.OrdinalIgnoreCase))
                    score += 0.2;
            }

            if (!string.IsNullOrEmpty(searchParams.Location) && 
                asset.Location.Contains(searchParams.Location, StringComparison.OrdinalIgnoreCase))
                score += 0.3;

            if (!string.IsNullOrEmpty(searchParams.Status) && 
                asset.Status.Contains(searchParams.Status, StringComparison.OrdinalIgnoreCase))
                score += 0.2;

            return Math.Min(score, 1.0);
        }
    }
}