using Microsoft.AspNetCore.Mvc;

namespace Curiosity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register() { /* Logica ASP.NET Identity Register va veni aici */ return Ok(); }

        [HttpPost("login")]
        public IActionResult Login() { /* Logica de generare JWT va veni aici */ return Ok(); }
    }
}
