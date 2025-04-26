namespace API.Models;

public class CinemaRoom
{
    public int Id { get; set; }
    public string name { get; set; }
    
    public List<Seat> seats { get; set; } = new();
    
    public ICollection<Showing> Showings { get; set; }
}