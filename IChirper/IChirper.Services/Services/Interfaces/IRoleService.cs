using IChirper.Models;
using IChirper.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IChirper.Services.Interfaces;

public interface IRoleService
{
    IdentityRole? GetRoleByName(string name);
    Task AddUserToRole(User user, string roleName);
    Task DeleteUserFromRole(User user);
    Task<bool> IsRoleAdmin(User user);
    Task<bool> IsRoleUser(User user);
    string GetUserRole(User user);
}