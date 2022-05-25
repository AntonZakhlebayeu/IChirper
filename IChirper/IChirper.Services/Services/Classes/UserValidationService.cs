using IChirper.Data.Interfaces;
using IChirper.Services.Interfaces;

namespace IChirper.Services.Classes;

public class UserValidationService : IUserValidation
{
    private readonly IUserRepository _userRepository;
    
    public UserValidationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public bool IsUserNullOrBlocked(string email)
    {
        var user = _userRepository.GetSingleAsync(u => u.UserName == email).Result;

        return user == null || user.Status == "Blocked User";
    }

    public bool IsUserNull(string email)
    {
        var user = _userRepository.GetSingleAsync(u => u.UserName == email).Result;
        
        return user == null;
    }
    
    public bool IsUserIsAuthenticatedAndNull(string email, bool isAuthenticated)
    {
        var user = _userRepository.GetSingleAsync(user => user.UserName == email && user.Status != "Blocked User").Result;

        Console.WriteLine(isAuthenticated);

        return user == null && isAuthenticated;
    }
}