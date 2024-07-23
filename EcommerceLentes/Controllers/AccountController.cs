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

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user) 
        {
            var result = await _userService.RegisterAsync(user);
            if (result)
            {
                return Ok(new { message = "Usuario registrado con éxito!" });
            }
            return BadRequest(new { message = "El usuario ya existe!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userService.LoginAsync(model.Email, model.Password);
            if (user != null)
            {
                return Ok(new { message = "Login exitoso!" });
            }
            return Unauthorized(new { message = "Credenciales inválidas." });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return Ok(new { message = "Logged out exitoso!" });
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
