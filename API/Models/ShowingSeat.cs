using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ShowingSeat
{
    public int Id { get; set; } 
    public char seatRow { get; set; }
    
    public int seatNumber { get; set; }
    public string type { get; set; }
    public double additionalPrice { get; set; }
    public bool isAvailable { get; set; }
    
    public int ShowingId { get; set; }
    public Showing Showing { get; set; }
    
}