namespace API.Models;

public class CinemaRoom
{
    public int Id { get; set; }
    public string name { get; set; }
    public int totalRows { get; set; }
    public int seatsPerRow  { get; set; }
    
    public ICollection<Showing> Showings { get; set; }
}