
namespace API.Models;

public class Showing
{
    public int id { get; set; }
    public bool is3D { get; set; }
    public double basePrice { get; set; }
    public DateTime date { get; set; }
    
    public int cinemaRoomId { get; set; }
    public CinemaRoom cinemaRoom { get; set; }
    
    public int movieId { get; set; }
    public Movie movie { get; set; }
    
    public ICollection<ShowingSeat> seats { get; set; }
    public ICollection<Booking> bookings { get; set; }
}