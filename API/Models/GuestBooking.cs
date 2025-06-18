namespace API.Models;

public class GuestBooking
{
    public int id { get; set; }
    public DateTime bookingDate { get; set; }
    public double price { get; set; }
    public bool isCancelled { get; set; }
    
    public string guestFirstName { get; set; }
    public string guestLastName { get; set; }
    public string guestEmail { get; set; }
    
    public int showingId { get; set; }
    public Showing showing { get; set; }
    
    public ICollection<ShowingSeat> seats { get; set; }
}