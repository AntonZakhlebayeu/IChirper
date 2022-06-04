using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IChirper.Controllers;

public class PageController : Controller
{
    
    [HttpGet]
    public IActionResult CreatePageView()
    {
        return View("CreatePage");
    }

    [HttpPost]
    public async Task<IActionResult> CreatePage(PageViewModel model)
    {
        

        return await Task.Run(() => NoContent());
    }
}