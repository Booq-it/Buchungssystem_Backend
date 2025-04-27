
namespace API.Models;

public class Showing
{
    public int Id { get; set; }
    public bool is3D { get; set; }
    public double basePrice { get; set; }
    public DateTime date { get; set; }
    
    public int CinemaRoomId { get; set; }
    public CinemaRoom CinemaRoom { get; set; }
    
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    
    public ICollection<ShowingSeat> Seats { get; set; }
    public ICollection<Booking> Bookings { get; set; }
}