using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetAllMovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();

            if (movies == null)
                return NotFound("No movies found!");

            return Ok(movies);
        }
        
        [HttpGet("GetMovieById")]
        public async Task<IActionResult> GetMovieById([FromQuery] int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null)
                return Ok(-1);

            return Ok(movie);
        }
    }
}
