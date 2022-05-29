using IChirper.Services.Interfaces;
using IChirper.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IChirper.@base.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly IUserValidation _userValidation;

    public AccountController(IUserValidation userValidation, IUserService userService)
    {
        _userValidation = userValidation;
        _userService = userService;
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) 
            return await Task.Run(() => View("Register", model));

        var result = await _userService.SaveNewUser(model, model.Password!, model.Role!);
        
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return await Task.Run(() => View("Register", model));
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return await Task.Run(() => View("Login", model));

        if (_userValidation.IsUserNullOrBlocked(model.Email!)) 
            return RedirectToAction("Index", "Home");

        var result = await _userService.LoginUser(model);

        if (result.Succeeded)
        {
            var user = await _userService.GetUserByEmail(model.Email!);
            
            user.LastLoginDate = DateTime.Now;

            var saveResult = _userService.Save();

            return !saveResult.IsCompletedSuccessfully ? RedirectToAction("Login", "Account") : RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Incorrect email and (or) password!");

        return await Task.Run(() => View("Login", model));
    }
    
    
    [Route("/Account/Logout")]
    public async Task<IActionResult> Logout()
    {
        if (_userValidation.IsUserNull(User.Identity!.Name!))
        {
            await _userService.LogoutUser();
            return await Task.Run(() => RedirectToAction("Index", "Home"));
        }
        
        var user = await _userService.GetUserByEmail(User.Identity.Name!);
        user.LastLoginDate = DateTime.Now;

        await _userService.Save();
        await _userService.LogoutUser();
        
        return await Task.Run(() => RedirectToAction("Index", "Home"));
    }
}