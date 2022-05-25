using IChirper.Data.Interfaces;
using IChirper.Models;
using IChirper.Services.Interfaces;
using IChirper.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IChirper.Services.Classes;

public class UserService : IUserService
{
    private readonly SignInManager<User> _signInManager;
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly IRoleService _roleService;

    private static UserViewModel GetUserViewModel(User model)
    {
        return new UserViewModel { Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, NickName = model.NickName, Age = model.Age, RegisterDate = model.RegisterDate, LastLoginDate = model.LastLoginDate, Status = model.Status };
    }

    private List<UserViewModel> GetUserViewModels(List<User> models)
    {
        return models.Select(GetUserViewModel).ToList();
    }

    public async Task<User> GetUserWithViewModel(UserViewModel model)
    {
        return (await _userRepository.GetSingleAsync(u => u.UserName == model.Email))!;
    }

    public UserService(IUserRepository userRepository, UserManager<User> userManager, IRoleService roleService, SignInManager<User> signInManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _roleService = roleService;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> SaveNewUser(RegisterViewModel model, string password, string role)
    {
        var userToSave = new User { Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, NickName = model.NickName, Age = model.Age, UserName = model.Email, RegisterDate = DateTime.Now, LastLoginDate = DateTime.Now, Status = "Active User"};
        
        var result = await _userManager.CreateAsync(userToSave, password);
        _userManager.PasswordHasher = new PasswordHasher<User>();
        _userManager.PasswordHasher.HashPassword(userToSave, password);
        
        await _roleService.AddUserToRole(userToSave, role);
        
        await _signInManager.SignInAsync(userToSave, false);

        return result;
    }

    public async Task<SignInResult> LoginUser(LoginViewModel model)
    {
        var result = 
            await _signInManager.PasswordSignInAsync(model.Email, model.Password!, model.RememberMe, false);

        return result;
    }

    public async ValueTask LogoutUser()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<UserViewModel> GetUserByEmail(string email)
    {
        return GetUserViewModel(await Task.FromResult(_userRepository.GetSingleAsync(u => u.UserName == email).GetAwaiter().GetResult()!));
    }

    public List<UserViewModel> GetAllUsers()
    {
        return GetUserViewModels(_userRepository.GetAll().ToList());
    }

    public async ValueTask Save()
    {
        await _userRepository.CommitAsync();
    }

    public async Task<UserViewModel?> GetUserById(string id)
    {
         return GetUserViewModel((await _userRepository.FindAsync(id))!);
    }

    public async Task Delete(UserViewModel model)
    {
        var user = await _userRepository.GetSingleAsync(u => u.UserName == model.Email);
        _userRepository.Delete(user!);
        await _userRepository.CommitAsync();
    }
}