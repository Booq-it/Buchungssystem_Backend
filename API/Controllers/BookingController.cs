using API.InputDto;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        
        [HttpPost("MakeBooking")]
        public async Task<IActionResult> MakeBooking([FromQuery] BookingInputDto dto)
        {
            if (await _bookingService.MakeBooking(dto))
            {
                return Ok();
            }
            else
            {
                return Ok(-1);
            }
        }
        
        [HttpGet("GetAllBookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            
            if (bookings == null)
                return Ok(-1);
                
            return Ok(bookings);
        }
        
        [HttpGet("GetBookingById")]
        public async Task<IActionResult> GetBookingById([FromQuery] int id)
        {
            var booking = await _bookingService.GetBookingById(id);
            
            if (booking == null)
                return Ok(-1);
            
            return Ok(booking);
        }

        [HttpGet("GetBookingsByUserId")]
        public async Task<IActionResult> GetBookingsByUserId([FromQuery] int userId)
        {
            var bookings = await _bookingService.GetBookingsByUserId(userId);
            
            if (bookings == null)
                return Ok(-1);
            
            return Ok(bookings);       
        }
    }
}
