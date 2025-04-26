using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Showing
{
    public int Id { get; set; }
    public bool is3D { get; set; }
    public double basePrice { get; set; }
    public DateTime date { get; set; }
    
    [ForeignKey("CinemaRoom")]
    public int CinemaRoomId { get; set; }
    public CinemaRoom CinemaRoom { get; set; }
    
    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    
}