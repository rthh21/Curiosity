using Curiosity.Api.DTOs;
using Curiosity.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curiosity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgenciesController : ControllerBase
    {
        private readonly IAgencyService _agencyService;
        private readonly ILogger<AgenciesController> _logger;

        public AgenciesController(IAgencyService agencyService, ILogger<AgenciesController> logger)
        {
            _agencyService = agencyService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgencyDto>>> Get()
        {
            _logger.LogInformation("Fetching all agencies.");
            var agencies = await _agencyService.GetAllAgenciesAsync();
            return Ok(agencies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgencyDto>> GetById(int id)
        {
            _logger.LogInformation("Fetching agency with ID {AgencyId}.", id);
            var agency = await _agencyService.GetAgencyByIdAsync(id);
            if (agency == null) return NotFound();
            return Ok(agency);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateAgencyDto dto)
        {
            _logger.LogWarning("Admin is creating a new agency: {AgencyName}.", dto.Name);
            await _agencyService.CreateAgencyAsync(dto);
            return Ok(new { message = "Agency created successfully!" });
        }
    }
}
