using Microsoft.AspNetCore.Mvc;

namespace IChirper.Controllers;

public class PostController : Controller
{
    public IActionResult CreateNewPost()
    {

        return NoContent();
    }

    public void DeletePost()
    {
        
    }
}