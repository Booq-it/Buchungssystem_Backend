using API.Data;
using API.OutputDto;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllMovies();
        Task<MovieDto> GetMovieById(int id);
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
            var movies = await _db.movies.ToListAsync();

            var moviesDtos = new List<MovieDto>();
            
            foreach (var movie in movies)
            {
                var dto = new MovieDto()
                {
                    id = movie.id,
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

        public async Task<MovieDto> GetMovieById(int id)
        {
            var movie = await _db.movies.FirstOrDefaultAsync(m => m.id == id);
            
            if (movie == null)
                return null;

            return new MovieDto
            {
                id = movie.id,
                name = movie.name,
                posterUrl = movie.posterUrl,
                genre = movie.genre,
                director = movie.director,
                duration = movie.duration,
                fsk = movie.fsk,
                description = movie.description,
                isFeatured = movie.isFeatured
            };
        }
    }
}

