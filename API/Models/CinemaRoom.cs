namespace API.Models;

public class CinemaRoom
{
    public int id { get; set; }
    public string name { get; set; }
    public int totalRows { get; set; }
    public int seatsPerRow  { get; set; }
    
    public ICollection<Showing> showings { get; set; }
}