namespace API.InputDto;

public class GuestBookingInput
{
    public string GuestFirstName { get; set; }
    public string GuestLastName { get; set; }
    public string GuestEmail { get; set; }
    public int showingId { get; set; }
    public double price { get; set; }
        
    public ICollection<int> seatIds { get; set; } 
}