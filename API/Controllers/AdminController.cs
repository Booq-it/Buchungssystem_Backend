using API.InputDto;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        
        [HttpPost("AddMovie")]
        public IActionResult AddMovie(MovieInputDto dto)
        {
            if (_adminService.AddMovie(dto))
            {
                return Ok("Added movie successfully!");
            }
            else
            {
                return Ok(-1);
            }
        }
        
        [HttpPut("EditMovie")]
        public IActionResult EditMovie(MovieInputDto dto)
        {
            if (_adminService.EditMovie(dto))
            {
                return Ok("Edited movie successfully!");
            }
            else
            {
                return Ok(-1);
            }
        }
        
        [HttpDelete("DeleteMovie")]
        public IActionResult EditMovie(int id)
        {
            if (_adminService.DeleteMovie(id))
            {
                return Ok("Deleted movie successfully!");
            }
            else
            {
                return Ok(-1);
            }
        }

        [HttpPost("AddShowing")]
        public IActionResult AddShowing(ShowingInputDto dto)
        {
            if (_adminService.AddShowing(dto))
            {
                return Ok("Added showing successfully!");
            }
            else
            {
                return Ok(-1);
            }
        }

        [HttpPut("EditShowing")]
        public IActionResult EditShowing(ShowingInputDto dto, int id)
        {
            if (_adminService.EditShowing(dto, id))
            {
                return Ok("Edited showing successfully!");
            }
            else
            {
                return Ok(-1);
            }
        }

        [HttpDelete("DeleteShowing")]
        public IActionResult DeleteShowing(int id)
        {
            if (_adminService.DeleteShowing(id))
            {
                return Ok("Deleted showing successfully!");
            }
            else
            {
                return Ok(-1);
            }
        }

        [HttpPost("AddBookingByUserId")]
        public async Task<IActionResult> AddBookingByUserId(BookingInputDto dto)
        {
            if (await _adminService.AddBookingByUserId(dto))
            {
                return Ok("Added booking successfully!");
            }
            else
            {
                return Ok(-1);
            }
        }
    }
}
