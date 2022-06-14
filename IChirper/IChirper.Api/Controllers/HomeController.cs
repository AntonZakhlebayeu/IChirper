using System.Diagnostics;
using IChirper.Controllers.Services.Interfaces;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IChirper.Controllers;

public class HomeController : Controller
{
    private readonly IUserService _userService;
    private readonly IPageService _pageService;
    
    public HomeController(IUserService userService, IPageService pageService)
    {
        _userService = userService;
        _pageService = pageService;
    }
    
    public async Task<IActionResult> Index()
    {
        var pages = await _pageService.GetAllPages();
        
        return View("Index", pages);
    }

    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var user = await _userService.GetUserByEmail(User.Identity?.Name!);
        
        return View(user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}