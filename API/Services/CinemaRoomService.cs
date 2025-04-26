using API.Data;
using API.Models;
using API.OutputDto;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface ICinemaRoomService
    {
        Task<List<CinemaRoomDto>> GetAllCinemaRooms();
        Task<SeatDto> GetSeat(string seatNumber, int cinemaRoomId);
    }
    
    public class CinemaRoomService : ICinemaRoomService
    {
        private readonly BackendDbContext _db;

        public CinemaRoomService(BackendDbContext db)
        {
            _db = db;
        }

        public async Task<List<CinemaRoomDto>> GetAllCinemaRooms()
        {
            var rooms = await _db.CinemaRooms
                .Include(s => s.seats)
                .ToListAsync();

            var cinemaRooms = new List<CinemaRoomDto>();
            
            foreach (var room in rooms)
            {
                var dto = new CinemaRoomDto
                {
                    id = room.Id,
                    name = room.name,
                    seats = room.seats.Select(s => new SeatDto
                    {
                        id = s.Id,
                        seatNumber = s.seatNumber,
                        type = s.type,
                        additionalPrice = s.additionalPrice,
                        isAvailable = s.isAvailable
                         
                    }).ToList()
                };
                cinemaRooms.Add(dto);
            }
            
            return cinemaRooms;
        }

        public async Task<SeatDto> GetSeat(string seatNumber, int cinemaRoomId)
        {
            var seat =  await _db.Seats.FirstOrDefaultAsync(s => s.seatNumber == seatNumber && s.CinemaRoomId == cinemaRoomId);

            if (seat == null) return null;
            
            Console.Write(seat.CinemaRoomId);
            
            var dto = new SeatDto
            {
                id = seat.Id,
                seatNumber = seat.seatNumber,
                type = seat.type,
                additionalPrice = seat.additionalPrice,
                isAvailable = seat.isAvailable
            };
            
            return dto;
        }
        
    }    
}
