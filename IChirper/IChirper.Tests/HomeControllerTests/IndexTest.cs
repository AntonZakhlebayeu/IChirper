using IChirper.Controllers;
using IChirper.Services.Classes;
using IChirper.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IChirper.Tests;

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