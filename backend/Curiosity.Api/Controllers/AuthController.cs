using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Curiosity.Api.Entities;

namespace Curiosity.Api.Controllers
{
    public class RegisterDto
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var userExists = await _userManager.FindByEmailAsync(dto.Email);
            if (userExists != null)
                return BadRequest(new { message = "User already exists!" });

            var names = dto.Name?.Split(' ', 2) ?? new[] { "Explorer" };
            var firstName = names[0];
            var lastName = names.Length > 1 ? names[1] : "";

            var user = new ApplicationUser()
            {
                Email = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = dto.Username,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = dto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest(new { message = "User creation failed: " + errors });
            }

            return Ok(new { username = user.UserName, token = "auth-token-generated", message = "User created successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email) 
                    ?? await _userManager.FindByNameAsync(dto.Email);
                    
            if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                return Ok(new { token = "auth-token-generated", username = user.UserName });
            }
            return Unauthorized(new { message = "Invalid email/username or password" });
        }

        [HttpGet("profile/{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound(new { message = "User not found" });

            return Ok(new
            {
                username = user.UserName,
                email = user.Email,
                phoneNumber = user.PhoneNumber,
                firstName = user.FirstName,
                lastName = user.LastName
            });
        }

        public class UpdateProfileDto
        {
            public string CurrentUsername { get; set; } = string.Empty;
            public string NewUsername { get; set; } = string.Empty;
            public string? PhoneNumber { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.CurrentUsername);
            if (user == null) return NotFound(new { message = "User not found" });

            if (dto.CurrentUsername != dto.NewUsername)
            {
                var existingUser = await _userManager.FindByNameAsync(dto.NewUsername);
                if (existingUser != null) return BadRequest(new { message = "Username already taken" });
                await _userManager.SetUserNameAsync(user, dto.NewUsername);
            }

            user.PhoneNumber = dto.PhoneNumber;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest(new { message = "Failed to update profile: " + errors });
            }

            return Ok(new { message = "Profile updated successfully", username = user.UserName });
        }
    }
}
