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

        public LaunchesController(ILaunchService launchService)
        {
            _launchService = launchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaunchDto>>> Get()
        {
            var launches = await _launchService.GetUpcomingLaunchesAsync();
            return Ok(launches);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post() => Ok();
    }
}
