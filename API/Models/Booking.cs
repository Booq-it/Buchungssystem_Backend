namespace API.Models;

public class Booking
{
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public int price { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int ShowingId { get; set; }
    public Showing Showing { get; set; }
    
    public ICollection<ShowingSeat> Seats { get; set; } 
    
}
    
    
    