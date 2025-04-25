using Microsoft.AspNetCore.Mvc;
using API.InputDto;
using API.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _authService.RegisterAsync(dto);
            return Ok(new { message = "Registration was succesful!"});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            await _authService.LoginAsync(dto);
            return Ok(new { message = "Login was succesful!"});
        }
    }
}
