namespace API.Models;

public class User
{
    public Guid Id { get; set; }
    public string email { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public byte[] passwordHash { get; set; }
    public byte[] passwordSalt { get; set; }
    public string role { get; set; } = "User";
}