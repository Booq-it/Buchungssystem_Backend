using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using API.InputDto;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuchungController : ControllerBase
    {

        [HttpGet("GetBuchung")]
        public async Task<ActionResult<string>> Get()
        {
            return Ok();
        }


    }
}
