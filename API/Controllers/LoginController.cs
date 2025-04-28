using Microsoft.AspNetCore.Mvc;
using API.InputDto;
using API.Models;
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
            if (await _authService.RegisterAsync(dto))
            {
                return Ok(new { message = "Registration was succesful!"});
            }
            else
            {
                return Ok(-1);
            }
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            User u = await _authService.LoginAsync(dto);
            
            if (u == null)
                return Ok(-1);
            
            return Ok(new { Guid = u.Id, email = u.email, firstName = u.firstName, lastName = u.lastName, role = u.role});
        }
    }
}
