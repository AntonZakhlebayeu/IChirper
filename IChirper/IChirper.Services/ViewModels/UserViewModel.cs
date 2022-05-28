namespace IChirper.ViewModels;

public class UserViewModel
{
    public string? Email { get; set; }
    public string? FirstName { get; init; }
    public string? LastName { get; set; }
    public string? NickName { get; set; }
    public int Age { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime LastLoginDate { get; set; }
    public string? Status { get; set; }

    public override bool Equals(object? obj)
    {
        var userViewModel = obj as UserViewModel;

        return (Email == userViewModel!.Email &&
                FirstName == userViewModel.FirstName &&
                LastName == userViewModel.LastName &&
                NickName == userViewModel.NickName &&
                Age == userViewModel.Age &&
                RegisterDate == userViewModel.RegisterDate &&
                LastLoginDate == userViewModel.LastLoginDate &&
                Status == userViewModel.Status
            );
    }

    protected bool Equals(UserViewModel other)
    {
        return Email == other.Email && FirstName == other.FirstName && LastName == other.LastName && NickName == other.NickName && Age == other.Age && RegisterDate.Equals(other.RegisterDate) && LastLoginDate.Equals(other.LastLoginDate) && Status == other.Status;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FirstName, LastName, NickName, Age, RegisterDate, LastLoginDate, Status);
    }
}