using IChirper.Controllers.Services.Interfaces;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IChirper.Controllers;

public class PageController : Controller
{
    private readonly IPageService _pageService;

    public PageController(IPageService pageService)
    {
        _pageService = pageService;
    }

    [HttpGet]
    public IActionResult CreatePage()
    {
        return View("CreatePage");
    }

    [HttpPost]
    public async Task<IActionResult> CreatePage(CreatePageViewModel model)
    {
        if (!ModelState.IsValid) return View("CreatePage", model);

        await _pageService.AddNewPage(model);

        return await Task.Run(() => RedirectToAction("Index", "Home"));
    }
}