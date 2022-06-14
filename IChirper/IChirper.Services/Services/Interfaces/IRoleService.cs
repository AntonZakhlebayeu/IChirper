using IChirper.Controllers.Models;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IChirper.Controllers.Services.Interfaces;

public interface IRoleService
{
    IdentityRole? GetRoleByName(string name);
    Task AddUserToRole(User user, string roleName);
    Task DeleteUserFromRole(User user);
    Task<bool> IsRoleAdmin(User user);
    Task<bool> IsRoleUser(User user);
    string GetUserRole(User user);
}