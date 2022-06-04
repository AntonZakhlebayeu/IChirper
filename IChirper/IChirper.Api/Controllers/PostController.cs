using Microsoft.AspNetCore.Mvc;

namespace IChirper.Controllers.Controllers;

public class PostController : Controller
{

    public IActionResult CreateNewPost()
    {
        var rfc4122bytes = Convert.FromBase64String("Hello-world");
        Array.Reverse(rfc4122bytes,0,4);
        Array.Reverse(rfc4122bytes,4,2);
        Array.Reverse(rfc4122bytes,6,2);
        var guid = new Guid(rfc4122bytes);
        
        Console.WriteLine(guid);

        return NoContent();
    }

    public void DeletePost()
    {
        
    }
}