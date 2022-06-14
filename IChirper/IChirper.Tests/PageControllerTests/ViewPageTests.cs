using IChirper.Controllers;
using IChirper.Controllers.Services.Interfaces;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using static IChirper.Controllers.Tests.AccountControllerTests.GetMockData;

namespace IChirper.Tests.PageControllerTests;

public class ViewPageTests
{
    [Fact]
    public async Task ViewValidPage()
    {
        const int testId = 1;
        
        //Arrange 
        var mockPageService = new Mock<IPageService>();
        mockPageService.Setup(service => service.GetPageById(testId).Result).Returns(GetTestPage(testId));
        var pageController = new PageController(mockPageService.Object);

        //Act
        var result = await pageController.ViewPage(testId) as ViewResult;
        
        //Arrange
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult.Model);
        Assert.Equal(GetTestPage(testId), viewResult.Model);
        Assert.Equal("PageView", viewResult.ViewName);
    }

    [Fact]
    public async Task SendInvalidPageId()
    {
        const int testId = 0;
        
        //Arrange
        var mockPageService = new Mock<IPageService>();
        mockPageService.Setup(service => service.GetPageById(testId).Result).Returns(GetTestPage(testId));
        var pageController = new PageController(mockPageService.Object);
        
        //Act
        var result = await pageController.ViewPage(testId) as RedirectToActionResult;
        
        //Arrange
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Home", redirectToActionResult.ControllerName);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }
    
    [Fact]
    public async Task FailedToFoundPage()
    {
        const int testId = 10;
        
        //Arrange
        var mockPageService = new Mock<IPageService>();
        mockPageService.Setup(service => service.GetPageById(testId).Result).Returns((PageViewModel)null!);
        var pageController = new PageController(mockPageService.Object);
        
        //Act
        var result = await pageController.ViewPage(testId) as RedirectToActionResult;
        
        //Arrange
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Home", redirectToActionResult.ControllerName);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }
}