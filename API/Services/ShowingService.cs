using API.Data;
using API.Models;
using API.OutputDto;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IShowingService
    {
        public Task<List<ShowingDto>> GetAllShowings();
        public Task<List<ShowingDto>> GetShowingsForDay(DateOnly date);
    }
    
    public class ShowingService : IShowingService
    {
        private readonly BackendDbContext _db;
        
        public ShowingService(BackendDbContext db)
        {
            _db = db;
        }

        public async Task<List<ShowingDto>> GetAllShowings()
        {
            var shows = await _db.Showings
                .Include(s => s.Seats)
                .ToListAsync();
            
            var showings = new List<ShowingDto>();
            
            foreach (var show in shows)
            {
                showings.Add(new ShowingDto
                {
                    id = show.Id,
                    is3D = show.is3D,
                    basePrice = show.basePrice,
                    date = show.date,
                    cinemaRoomId = show.CinemaRoomId,
                    movieId = show.MovieId,
                    seats = show.Seats.Select(s => new ShowingSeatDto
                    {
                        id = s.Id,
                        seatRow = s.seatRow,
                        seatNumber = s.seatNumber,
                        type = s.type,
                        additionalPrice = s.additionalPrice,
                        isAvailable = s.isAvailable
                    }).ToList()
                });
            }
            
            return showings;
        }
        
        public async Task<List<ShowingDto>> GetShowingsForDay(DateOnly date)
        {
            var shows =  await _db.Showings
                .Where(s => DateOnly.FromDateTime(s.date) == date)
                .ToListAsync();

            var showings = new List<ShowingDto>();

            foreach (var show in shows)
            {
                showings.Add(new ShowingDto
                {
                    id = show.Id,
                    is3D = show.is3D,
                    basePrice = show.basePrice,
                    date = show.date,
                    cinemaRoomId = show.CinemaRoomId,
                    movieId = show.MovieId,
                });
            }
            
            return showings;
        }
    }
}

