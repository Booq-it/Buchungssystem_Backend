namespace API.Models;

public class User
{
    public int id { get; set; }
    public string email { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public byte[] passwordHash { get; set; }
    public byte[] passwordSalt { get; set; }
    public int role { get; set; } = 1; // 1 = User, 2 = Admin
    public ICollection<Booking> bookings { get; set; } = new List<Booking>();
}