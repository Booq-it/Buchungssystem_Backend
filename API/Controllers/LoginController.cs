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
            var u = await _authService.LoginAsync(dto);
            
            if (u == null)
                return Ok(-1);
            
            return Ok(u);
        }

        [HttpPatch("ChangeUserInfo")]
        public async Task<IActionResult> ChangeUserInfo(ChangeUserInfoDto dto)
        {
            if (await _authService.ChangeUserInformation(dto.id, dto.email, dto.firstName, dto.lastName))
            {
                return Ok("User information was changed successfully!");
            }
            else
            {
                return Ok(-1);   
            }
        }

        [HttpPatch("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
        {
            if (await _authService.ChangeUserPassword(dto.id, dto.oldPassword, dto.newPassword))
            {
                return Ok("Password was changed successfully!");
            }
            else
            {
                return Ok(-1);  
            }
        }
    }
}
