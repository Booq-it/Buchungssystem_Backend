namespace API.InputDto;

public class ShowingInputDto
{
    public int movieId { get; set; }
    public int cinemaRoomId { get; set; }
    public bool is3D { get; set; }
    public double basePrice { get; set; }
    public DateTime date { get; set; }
}