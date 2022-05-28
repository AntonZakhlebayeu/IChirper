using System.Security.Claims;
using System.Security.Principal;
using IChirper.Controllers;
using IChirper.Models;
using IChirper.Services.Interfaces;
using IChirper.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IChirper.Tests;

public class ProfileTest
{
    [Fact]
    public async Task ProfileReturnAViewResultWithCorrectUser()
    {
        const string email = "example@example.com";
        
        //Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService.Setup(repo=> repo.GetUserByEmail(email)).Returns(GetTestUser());
        var homeController = new HomeController(mockUserService.Object);
        
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim("name", email),
        };
        var identity = new ClaimsIdentity(claims, "Test");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        var context = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = claimsPrincipal
            }
        };

        //Act
        homeController.ControllerContext = context;
        var result = await homeController.Profile() as ViewResult;
        
        //Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<UserViewModel>(viewResult.ViewData.Model);
        Assert.Equal(GetTestUser().Result, model);
    }
    
    private static async Task<UserViewModel> GetTestUser()
    {
        return await Task.Run(() => new UserViewModel { Email = "example@example.com", FirstName = "Test", LastName = "Test", NickName = "BlackM", Age = 18, RegisterDate = new DateTime(2022, 2, 24), LastLoginDate = new DateTime(2022, 2, 24), Status = "Active User" });
    }
}
