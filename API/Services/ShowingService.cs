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
        public Task<List<ShowingDto>> GetShowingsForMovie(int movieId);
        public Task<ShowingSeatDto> GetSeat(int id, int showingId);
        public Task<ShowingDto> GetShowingById(int id);
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
            var shows = await _db.showings
                .Include(s => s.seats)
                .ToListAsync();
            
            var showings = new List<ShowingDto>();
            
            foreach (var show in shows)
            {
                showings.Add(new ShowingDto
                {
                    id = show.id,
                    is3D = show.is3D,
                    basePrice = show.basePrice,
                    date = show.date,
                    cinemaRoomId = show.cinemaRoomId,
                    movieId = show.movieId,
                    seats = show.seats.Select(s => new ShowingSeatDto
                    {
                        id = s.id,
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
            var shows =  await _db.showings
                .Include(s => s.seats)
                .Where(s => DateOnly.FromDateTime(s.date) == date)
                .ToListAsync();

            var showings = new List<ShowingDto>();

            foreach (var show in shows)
            {
                showings.Add(new ShowingDto
                {
                    id = show.id,
                    is3D = show.is3D,
                    basePrice = show.basePrice,
                    date = show.date,
                    cinemaRoomId = show.cinemaRoomId,
                    movieId = show.movieId,
                    seats = show.seats.Select(s => new ShowingSeatDto
                    {
                        id = s.id,
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
        
        public async Task<List<ShowingDto>> GetShowingsForMovie(int movieId)
        {
            var shows =  await _db.showings
                .Include(s => s.seats)
                .Where(s => s.movieId == movieId)
                .ToListAsync();
            
            var showings = new List<ShowingDto>();
            
            foreach (var show in shows)
            {
                showings.Add(new ShowingDto
                {
                    id = show.id,
                    is3D = show.is3D,
                    basePrice = show.basePrice,
                    date = show.date,
                    cinemaRoomId = show.cinemaRoomId,
                    movieId = show.movieId,
                    seats = show.seats.Select(s => new ShowingSeatDto
                    {
                        id = s.id,
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

        public async Task<ShowingSeatDto> GetSeat(int id, int showingId)
        {
            var seat = await _db.showings
                .Where(s => s.id == showingId)
                .Include(s => s.seats)
                .SelectMany(s => s.seats)
                .FirstOrDefaultAsync(s => s.id == id);
            
            if (seat == null)
                return null;

            return new ShowingSeatDto
            {
                id = seat.id,
                seatRow = seat.seatRow,
                seatNumber = seat.seatNumber,
                type = seat.type,
                additionalPrice = seat.additionalPrice,
                isAvailable = seat.isAvailable
            };
        }
        
        public async Task<ShowingDto> GetShowingById(int id)
        {
            var show = await _db.showings
                .Include(s => s.seats)
                .FirstOrDefaultAsync(s => s.id == id);
            
            if (show == null)
                return null;

            return new ShowingDto
            {
                id = show.id,
                is3D = show.is3D,
                basePrice = show.basePrice,
                date = show.date,
                cinemaRoomId = show.cinemaRoomId,
                movieId = show.movieId,
                seats = show.seats.Select(s => new ShowingSeatDto
                {
                    id = s.id,
                    seatRow = s.seatRow,
                    seatNumber = s.seatNumber,
                    type = s.type,
                    additionalPrice = s.additionalPrice,
                    isAvailable = s.isAvailable
                }).ToList()
            };
        }
    }
}

