using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using watch_assets.Data;
using watch_assets.Middleware;
using watch_assets.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Entity Framework
builder.Services.AddDbContext<WatchAssetsContext>(options =>
    options.UseInMemoryDatabase("WatchAssetsDb"));

// Add AWS S3 Service
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddScoped<IAwsService, AwsService>();

// Add logging
builder.Services.AddLogging();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use performance monitoring middleware
app.UseMiddleware<PerformanceMonitoringMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();