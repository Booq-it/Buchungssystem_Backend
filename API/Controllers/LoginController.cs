using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using API.InputDto;
using Backend.Scripts;
using Backend.Classes;
using User = Backend.Classes.User;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [APIController]
    public class LoginController : ControllerBase
    {
        [HttpPost("LoginUser")]
        public async Task<ActionResult<string>> LoginUser(LoginDto loginDto)
        {
            Backend.Scripts.Controller controller = new Backend.Scripts.Controller();

            User user = controller.Login(loginDto.email, loginDto.password);

            if(user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }

    }
}
