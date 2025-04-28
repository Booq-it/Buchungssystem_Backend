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
                return Ok(-1);
                
            return Ok(rooms);
        }
        
        [HttpGet("GetCinemaRoomById")]
        public async Task<IActionResult> GetCinemaRoomById([FromQuery] int id)
        {
            var room = await _cinemaRoomService.GetCinemaRoomById(id);
            
            if (room == null)
                return Ok(-1);
                
            return Ok(room);
        }
        
    }
}