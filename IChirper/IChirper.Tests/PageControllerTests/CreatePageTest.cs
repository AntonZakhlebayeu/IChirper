using IChirper.Controllers;
using IChirper.Controllers.Services.Interfaces;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IChirper.Tests.PageControllerTests;

public class CreatePageTest
{
    [Fact]
    public void CreatePageViewNotNull()
    {
        //Arrange
        var mockPageService = new Mock<IPageService>();
        var pageController = new PageController(mockPageService.Object);
        
        //Act
        var result = pageController.CreatePage() as ViewResult;
        
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task SendInvalidPage()
    {
        //Arrange
        var mockPageService = new Mock<IPageService>();
        var pageController = new PageController(mockPageService.Object);
        var pageToCreate = new CreatePageViewModel()
        {
            Id = 1,
            Author = null,
            IsPrivate = true,
            PageDescription = "test",
            Title = "test"
        };
        pageController.ModelState.AddModelError("CreatePageViewModel", "Author field must be filled.");
        
        //Act
        var result = await pageController.CreatePage(pageToCreate) as ViewResult;

        //Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult.Model);
        Assert.Equal("CreatePage", viewResult.ViewName);
        Assert.Equal(pageToCreate, viewResult.Model);
    }

    [Fact]
    public async Task SendValidPage()
    {
        //Arrange
        var mockPageService = new Mock<IPageService>();
        var pageController = new PageController(mockPageService.Object);
        var pageToCreate = new CreatePageViewModel()
        {
            Id = 1,
            Author = null,
            IsPrivate = true,
            PageDescription = "test",
            Title = "test"
        };

        //Act
        var result = await pageController.CreatePage(pageToCreate) as ViewResult;

        //Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult.Model);
        Assert.Equal("CreatePage", viewResult.ViewName);
        Assert.Equal(pageToCreate, viewResult.Model);
    }
}