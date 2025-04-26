namespace API.OutputDto;

public class SeatDto
{
    public int id { get; set; } 
    public string seatNumber { get; set; }
    public string type { get; set; }
    public double additionalPrice { get; set; }
    public bool isAvailable { get; set; }
}