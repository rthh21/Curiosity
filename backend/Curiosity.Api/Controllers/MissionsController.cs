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
        private readonly ILogger<MissionsController> _logger;
        
        public MissionsController(IMissionService missionService, ILogger<MissionsController> logger)
        {
            _missionService = missionService;
            _logger = logger;
        }

        // GET: api/missions - Oricine poate vedea știrile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionDto>>> Get()
        {
            var missions = await _missionService.GetAllMissionsAsync();
            return Ok(missions);
        }

        // GET: api/missions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissionDto>> GetById(int id)
        {
            // Dacă serviciul aruncă KeyNotFoundException, execuția se oprește aici
            // și "sare" direct în Middleware-ul tău global.
            var mission = await _missionService.GetMissionByIdAsync(id);
            return Ok(mission);
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