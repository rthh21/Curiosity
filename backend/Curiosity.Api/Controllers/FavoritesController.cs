using Curiosity.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Curiosity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private readonly IMissionService _missionService;
        private readonly ILogger<FavoritesController> _logger;

        public FavoritesController(IMissionService missionService, ILogger<FavoritesController> logger)
        {
            _missionService = missionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyFavorites()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            _logger.LogInformation("User {UserId} is fetching their favorites.", userId);
            var favorites = await _missionService.GetUserFavoritesAsync(userId);
            return Ok(favorites);
        }

        [HttpPost("{missionId}")]
        public async Task<IActionResult> AddToFavorites(int missionId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            _logger.LogInformation("User {UserId} is adding mission {MissionId} to favorites.", userId, missionId);
            await _missionService.AddToFavoritesAsync(userId, missionId);
            return Ok(new { message = "Mission added to favorites." });
        }

        [HttpDelete("{missionId}")]
        public async Task<IActionResult> RemoveFromFavorites(int missionId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            _logger.LogInformation("User {UserId} is removing mission {MissionId} from favorites.", userId, missionId);
            await _missionService.RemoveFromFavoritesAsync(userId, missionId);
            return Ok(new { message = "Mission removed from favorites." });
        }
    }
}
