using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.InputDto;
using Backend.Scripts;
using Backend.Classes;
using Microsoft.OpenApi.Models;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("LoginUser")]
        public ActionResult<string> LoginUser(LoginDto loginDto)
        {
            Buchungssystem_Backend.Scripts.Controller controller = new Buchungssystem_Backend.Scripts.Controller();

            User user = controller.Login(loginDto.email, loginDto.password);

            if(user == null)
            {
                return Ok(-1);
            }

            return Ok(user);
        }

        [HttpPost("RegisterUser")]
        public ActionResult<string> RegisterUser(RegisterDto registerDto)
        {
            Buchungssystem_Backend.Scripts.Controller controller = new Buchungssystem_Backend.Scripts.Controller();

            int id = controller.Register(registerDto.email, registerDto.password, registerDto.firstName, registerDto.lastName, registerDto.age);

            return Ok(id);
        }
    }
}
