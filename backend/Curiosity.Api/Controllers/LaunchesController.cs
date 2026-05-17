using Curiosity.Api.DTOs;
using Curiosity.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curiosity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaunchesController : ControllerBase
    {
        private readonly ILaunchService _launchService;
        private readonly ILogger<LaunchesController> _logger;

        public LaunchesController(ILaunchService launchService, ILogger<LaunchesController> logger)
        {
            _launchService = launchService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaunchDto>>> Get()
        {
            _logger.LogInformation("Fetching upcoming launches.");
            var launches = await _launchService.GetUpcomingLaunchesAsync();
            return Ok(launches);
        }

        [HttpGet("past")]
        public async Task<ActionResult<IEnumerable<LaunchDto>>> GetPast()
        {
            _logger.LogInformation("Fetching past launches.");
            var launches = await _launchService.GetPastLaunchesAsync();
            return Ok(launches);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateLaunchDto dto)
        {
            _logger.LogWarning("Admin is creating a new launch for mission ID {MissionId}.", dto.MissionId);
            await _launchService.CreateLaunchAsync(dto);
            return Ok(new { message = "Launch created successfully!" });
        }
    }
}
