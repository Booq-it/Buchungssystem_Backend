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
                return Ok(-1);
            
            return Ok(showings);
        }

        [HttpGet("GetShowingsForDay")]
        public async Task<IActionResult> GetShowingsForDay([FromQuery] DateOnly date)
        {
            var showings = await _showingService.GetShowingsForDay(date);
                
            if (showings == null)
                return Ok(-1);
            
            return Ok(showings);
        }

        [HttpGet("GetShowingsByMovieId")]
        public async Task<IActionResult> GetShowingsByMovieId([FromQuery] int movieId)
        {
            var showings = await _showingService.GetShowingsForMovie(movieId);
            
            if (showings == null)
                return Ok(-1);
            
            return Ok(showings);
        }

        [HttpGet("GetSeatForShowing")]
        public async Task<IActionResult> GetSeatForShowing([FromQuery] GetSeatDto dto)
        {
            var seat = await _showingService.GetSeat(dto.id, dto.showingId);
            
            if(seat == null)
                return Ok(-1);
            
            return Ok(seat);
        }
        
        [HttpGet("GetShowingById")]
        public async Task<IActionResult> GetShowingById([FromQuery] int showingId)
        {
            var showing = await _showingService.GetShowingById(showingId);
            
            if(showing == null)
                return Ok(-1);
            
            return Ok(showing);
        }
    }
}