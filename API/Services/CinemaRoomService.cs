using API.Data;
using API.Models;
using API.OutputDto;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface ICinemaRoomService
    {
        Task<List<CinemaRoomDto>> GetAllCinemaRooms();
        Task<CinemaRoomDto> GetCinemaRoomById(int id);
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
            var rooms = await _db.cinemaRooms
                .Include(s => s.showings)
                .ToListAsync();

            var cinemaRooms = new List<CinemaRoomDto>();
            
            foreach (var room in rooms)
            {
                var dto = new CinemaRoomDto
                {
                    id = room.id,
                    name = room.name,
                    totalRows = room.totalRows,
                    seatsPerRow = room.seatsPerRow
                };
                cinemaRooms.Add(dto);
            }
            
            return cinemaRooms;
        }
        
        public async Task<CinemaRoomDto> GetCinemaRoomById(int id)
        {
            var room = await _db.cinemaRooms
                .Include(s => s.showings)
                .FirstOrDefaultAsync(s => s.id == id);
            
            if (room == null)
                return null;
            
            return new CinemaRoomDto
            {
                id = room.id,
                name = room.name,
                totalRows = room.totalRows,
                seatsPerRow = room.seatsPerRow
            };;
        }
    }    
}
