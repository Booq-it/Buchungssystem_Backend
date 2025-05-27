namespace API.Models;

public class GuestBooking
{
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public double Price { get; set; }
    public bool IsCancelled { get; set; }
    
    public string GuestFirstName { get; set; }
    public string GuestLastName { get; set; }
    public string GuestEmail { get; set; }
    
    public int ShowingId { get; set; }
    public Showing Showing { get; set; }
    
    public ICollection<ShowingSeat> Seats { get; set; }
}