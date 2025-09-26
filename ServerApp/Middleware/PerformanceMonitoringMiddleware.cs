namespace watch_assets.Middleware
{
    public class PerformanceMonitoringMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<PerformanceMonitoringMiddleware> _logger;

        public PerformanceMonitoringMiddleware(RequestDelegate next, ILogger<PerformanceMonitoringMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
            await _next(context);
            
            stopwatch.Stop();
            
            var responseTime = stopwatch.ElapsedMilliseconds;
            if (responseTime > 1000) // Log slow requests
            {
                _logger.LogWarning($"Slow request: {context.Request.Path} took {responseTime}ms");
            }
        }
    }
}