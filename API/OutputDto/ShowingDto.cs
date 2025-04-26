using API.Models;

namespace API.OutputDto;

public class ShowingDto
{
    public int id { get; set; }
    public bool is3D { get; set; }
    public double basePrice { get; set; }
    public DateTime date { get; set; }
    
    public int cinemaRoomId { get; set; }
    
    public int movieId { get; set; }
    
    public List<BookingDto>? bookings { get; set; }
}