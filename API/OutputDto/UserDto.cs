using API.InputDto;
using API.Models;

namespace API.OutputDto;

public class UserDto
{
    public int Id { get; set; }
    public string email { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int role { get; set; } = 1; 
    public List<int> bookingIds { get; set; }
}