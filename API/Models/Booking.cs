namespace API.Models;

public class Booking
{
    public int id { get; set; }
    public DateTime bookingDate { get; set; }
    public double price { get; set; }
    public bool isCancelled { get; set; }
    
    public int userId { get; set; }
    public User user { get; set; }

    public int showingId { get; set; }
    public Showing showing { get; set; }
    
    public ICollection<ShowingSeat> seats { get; set; } 
    
}
    
    
    