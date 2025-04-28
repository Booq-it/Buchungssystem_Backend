namespace API.InputDto;

public class ChangePasswordDto
{
    public int id { get; set; }
    public string oldPassword { get; set; }
    public string newPassword { get; set; }
}