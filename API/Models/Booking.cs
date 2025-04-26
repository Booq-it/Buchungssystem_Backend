namespace API.Models;

public class Booking
{
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public int userId { get; set; }
    public int showId { get; set; }
    public int price { get; set; }
    
    public List<string> seatnumbers { get; set; }
}