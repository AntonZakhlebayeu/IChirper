using IChirper.Models;
using IChirper.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IChirper.Services.Interfaces;

public interface IUserService
{
    Task<User> GetUserWithViewModel(UserViewModel model);
    Task<IdentityResult> SaveNewUser(RegisterViewModel user, string password, string role);
    Task<SignInResult> LoginUser(LoginViewModel model);
    ValueTask LogoutUser();
    Task<UserViewModel> GetUserByEmail(string email);
    ValueTask Save();
    List<UserViewModel> GetAllUsers();
    Task<UserViewModel?> GetUserById(string id);
    Task Delete(UserViewModel user);
}