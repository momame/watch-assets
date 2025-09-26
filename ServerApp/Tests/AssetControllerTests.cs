using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using watch_assets.Controllers;
using watch_assets.Data;
using watch_assets.Models;

namespace watch_assets.Tests
{
    public class AssetControllerTests
    {
        [Fact]
        public async Task GetAssets_ReturnsOkResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WatchAssetsContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new WatchAssetsContext(options);
            var controller = new AssetsController(context);

            // Act
            var result = await controller.GetAssets();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Asset>>>(result);
        }

        [Fact]
        public async Task GetAsset_WithValidId_ReturnsAsset()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WatchAssetsContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new WatchAssetsContext(options);
            var controller = new AssetsController(context);

            // Act
            var result = await controller.GetAsset(1);

            // Assert
            var okResult = Assert.IsType<ActionResult<Asset>>(result);
            Assert.NotNull(okResult.Value);
        }
    }
}