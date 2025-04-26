using API.InputDto;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowingController : ControllerBase
    {
        private readonly IShowingService _showingService;

        public ShowingController(IShowingService showingService)
        {
            _showingService = showingService;
        }

        [HttpGet("GetAllShowings")]
        public async Task<IActionResult> GetAllShowings()
        {
            var showings = await _showingService.GetAllShowings();

            if (showings == null)
                return NotFound("No movies found!");
            
            return Ok(showings);
        }

        [HttpGet("GetShowingsForDay")]
        public async Task<IActionResult> GetShowingsForDay([FromQuery] DateOnly date)
        {
            var showings = await _showingService.GetShowingsForDay(date);
                
            if (showings == null)
                return NotFound("No showings for that day!");
            
            return Ok(showings);
        }
    }
}