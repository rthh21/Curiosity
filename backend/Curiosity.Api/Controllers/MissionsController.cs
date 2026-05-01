using Curiosity.Api.DTOs;
using Curiosity.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curiosity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionsController : ControllerBase
    {
        private readonly IMissionService _missionService;

        public MissionsController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        // GET: api/missions - Oricine poate vedea știrile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionDto>>> Get()
        {
            var missions = await _missionService.GetAllMissionsAsync();
            return Ok(missions);
        }

        // POST: api/missions - DOAR ADMINUL poate adăuga știri (Cerință bifată)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateMissionDto dto)
        {
            await _missionService.CreateMissionAsync(dto);
            return Ok(new { message = "Mission news created successfully!" });
        }
    }
}