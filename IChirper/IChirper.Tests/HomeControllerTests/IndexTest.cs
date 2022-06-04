using IChirper.Controllers;
using IChirper.Controllers.Services.Interfaces;
using IChirper.Controllers.Services.Classes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IChirper.Controllers.Tests.HomeControllerTests;

public class HomeControllerTest
{
    [Fact]
    public void IndexViewNotNull()
    {
        //Arrange
        var mock = new Mock<IUserService>();
        var homeController = new HomeController(mock.Object);
        
        //Act
        var result = homeController.Index() as ViewResult;
        
        //Assert
        Assert.NotNull(result);
    }
}