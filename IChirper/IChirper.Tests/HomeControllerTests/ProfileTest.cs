using IChirper.Controllers;
using IChirper.Controllers.Services.Interfaces;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using static IChirper.Controllers.Tests.AccountControllerTests.GetMockData;

namespace IChirper.Controllers.Tests.HomeControllerTests;

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

        //Act
        homeController.ControllerContext = GetMockControllerContext();
        var result = await homeController.Profile() as ViewResult;
        
        //Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<UserViewModel>(viewResult.ViewData.Model);
        Assert.Equal(GetTestUser().Result, model);
    }
}
