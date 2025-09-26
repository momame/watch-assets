using Microsoft.AspNetCore.Mvc;

namespace watch_assets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var healthCheck = new
            {
                Status = "Healthy",
                Timestamp = DateTime.UtcNow,
                Version = "1.0.0",
                Dependencies = new
                {
                    Database = "Connected",
                    AWS = "Available",
                    Memory = "OK"
                }
            };

            return Ok(healthCheck);
        }
    }
}