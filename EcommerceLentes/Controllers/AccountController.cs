using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService) // => INYECCION DEPENDECNCIA. AccountController depende de la implementación de IUserService.
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user) // cuerpo solicitud formato JSON.
        {
            var result = await _userService.RegisterAsync(user);
            if (result)
            {
                return Ok(new { message = "User registered successfully!" });
            }
            return BadRequest(new { message = "User already exists." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model) // cuerpo solicitud formato JSON.
        {
            var user = await _userService.LoginAsync(model.Email, model.Password);
            if (user != null)
            {
                return Ok(new { message = "Login successful!" });
            }
            return Unauthorized(new { message = "Invalid email or password." });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return Ok(new { message = "Logged out successfully!" });
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
