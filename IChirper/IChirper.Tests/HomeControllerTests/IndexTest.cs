using IChirper.Controllers.Models;
using IChirper.Controllers.Services.Interfaces;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using static IChirper.Controllers.Tests.AccountControllerTests.GetMockData;

namespace IChirper.Controllers.Tests.HomeControllerTests;

public class HomeControllerTest
{
    [Fact]
    public async Task IndexReturnsAViewResultWithAListOfUsers()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var mockPageService = new Mock<IPageService>();
        mockPageService.Setup(service => service.GetAllPages().Result).Returns(GetTestPage());
        
        var homeController = new HomeController(mockUserService.Object, mockPageService.Object);
        
        //Act
        var result = await homeController.Index();
        
        //Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<PageViewModel>>(viewResult.Model);
        Assert.Equal(GetTestPage().Count, model.Count);
    }
}