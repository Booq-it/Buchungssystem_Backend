using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Seat
{
    public int Id { get; set; } 
    public string seatNumber { get; set; }
    public string type { get; set; }
    public double additionalPrice { get; set; }
    public bool isAvailable { get; set; }
    
    public int CinemaRoomId { get; set; }
    
    public CinemaRoom CinemaRoom { get; set; }
    
    [ForeignKey("Booking")]
    public List<int> bookingIds { get; set; }
    public Booking Booking { get; set; }
}