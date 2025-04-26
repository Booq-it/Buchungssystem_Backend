using API.InputDto;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaRoomController : ControllerBase
    {
        private readonly ICinemaRoomService _cinemaRoomService;
        
        public CinemaRoomController(ICinemaRoomService cinemaRoomService)
        {
            _cinemaRoomService = cinemaRoomService;
        }

        
        [HttpGet("GetAllCinemaRooms")]
        public async Task<IActionResult> GetAllCinemaRooms()
        {
            var rooms = await _cinemaRoomService.GetAllCinemaRooms();

            if (rooms == null)
                return NotFound("No cinema rooms found!");
                
            return Ok(rooms);
        }

        [HttpGet("GetSeat")]
        public async Task<IActionResult> GetSeat(GetSeatDto dto)
        {
            var seat = await _cinemaRoomService.GetSeat(dto.seatNumber, dto.roomId);

            if (seat == null)
            {
                return NotFound("Seat not found!");
            }
            
            return Ok(seat);
        }
    }
}