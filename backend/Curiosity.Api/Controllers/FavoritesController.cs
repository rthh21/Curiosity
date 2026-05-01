using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curiosity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Trebuie să fii logat ca să ai favorite
    public class FavoritesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMyFavorites() => Ok();
    }
}
