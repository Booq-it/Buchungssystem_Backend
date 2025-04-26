namespace API.OutputDto;

public class CinemaRoomDto
{
    public int id { get; set; }
    public string name { get; set; }
    
    public List<SeatDto> seats { get; set; }
}