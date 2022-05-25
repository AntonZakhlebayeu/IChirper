namespace IChirper.Services.Interfaces;

public interface IUserValidation
{
    bool IsUserNullOrBlocked(string email);
    bool IsUserNull(string email);
    bool IsUserIsAuthenticatedAndNull(string email, bool isAuthenticated);
}