namespace IChirper.ViewModels;

public class UserViewModel
{
    public string? Email { get; set; }
    public string? FirstName { get; init; }
    public string? LastName { get; set; }
    public string? NickName { get; set; }
    public string? UserName { get; set; }
    public int Age { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime LastLoginDate { get; set; }
    public string? Status { get; set; }
}