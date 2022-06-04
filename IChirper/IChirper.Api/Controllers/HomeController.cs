﻿using System.Diagnostics;
using IChirper.Controllers.Services.Interfaces;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IChirper.Controllers;

public class HomeController : Controller
{
    private readonly IUserService _userService;
    public HomeController(IUserService userService)
    {
        _userService = userService;
    }
    
    public IActionResult Index()
    {
        return View("Index");
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