using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Scripts;
using Backend.Classes;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowingController : ControllerBase
    {
        [HttpGet]
        public IActionResult getShowings()
        {
            Buchungssystem_Backend.Scripts.Controller controller = new Buchungssystem_Backend.Scripts.Controller();

            List<Showing> answer = controller.GetShowings();

            return Ok(answer);
        }
    }
}
