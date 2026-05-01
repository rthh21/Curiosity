using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curiosity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaunchesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new string[] { "Launch 1", "Launch 2" });

        // DOAR ADMINUL poate adăuga lansări (Cerință bifată - Al doilea endpoint protejat)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post() => Ok();
    }
}
