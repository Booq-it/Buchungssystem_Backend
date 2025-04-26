using API.Data;
using API.OutputDto;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllMovies();
    }
    
    public class MovieService : IMovieService
    {
        private readonly BackendDbContext _db;

        public MovieService(BackendDbContext db)
        {
            _db = db;
        }

        public async Task<List<MovieDto>> GetAllMovies()
        {
            var movies = await _db.Movies.ToListAsync();

            var moviesDtos = new List<MovieDto>();
            
            foreach (var movie in movies)
            {
                var dto = new MovieDto()
                {
                    id = movie.Id,
                    name = movie.name,
                    posterUrl = movie.posterUrl,
                    genre = movie.genre,
                    director = movie.director,
                    duration = movie.duration,
                    fsk = movie.fsk,
                    description = movie.description,
                    isFeatured = movie.isFeatured
                };
                moviesDtos.Add(dto);
            }
            
            return moviesDtos;
        }
    }
}

