namespace API.Models;

public class Movie
{
    public int id { get; set; }
    public string name { get; set; }
    public string posterUrl { get; set; }
    public string genre { get; set; }
    public string director { get; set; }
    public int duration { get; set; }
    public int fsk { get; set; }
    public string description { get; set; }
    
    public bool isFeatured { get; set; }
    
    public ICollection<Showing> showings { get; set; }
    
}