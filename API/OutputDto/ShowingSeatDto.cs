namespace API.OutputDto;

public class ShowingSeatDto
{
    public int id { get; set; } 
    public char seatRow { get; set; }
    public int seatNumber { get; set; }
    public string type { get; set; }
    public double additionalPrice { get; set; }
    public bool isAvailable { get; set; }
}