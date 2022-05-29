using IChirper.@base.Controllers;
using IChirper.Services.Interfaces;
using IChirper.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IChirper.Tests.AccountControllerTests;

public class RegisterTest
{
    [Fact]
    public void RegisterViewNotNull()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var mockUserValidation = new Mock<IUserValidation>();
        var accountController = new AccountController(mockUserValidation.Object, mockUserService.Object);
        
        //Act
        var result = accountController.Login() as ViewResult;
        
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task SendToRegisterInvalidUser()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var mockUserValidation = new Mock<IUserValidation>();
        var accountController = new AccountController(mockUserValidation.Object, mockUserService.Object);
        var userToRegister = new RegisterViewModel()
        {
            Email = null,
            FirstName = null,
            LastName = null,
            Age = 0,
            Password = null,
            PasswordConfirm = null
        };
        accountController.ModelState.AddModelError("UserViewModel", "Email field must be filled.");

        //Act
        var result = await accountController.Register(userToRegister) as ViewResult;
        
        //Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult.Model);
        Assert.Equal("Register", viewResult.ViewName);
        Assert.Equal(userToRegister, viewResult.Model);
    }

    [Fact]
    public async Task SendToRegisterValidUser()
    {
        //Arrange 
        var mockUserService = new Mock<IUserService>();
        var mockUserValidation = new Mock<IUserValidation>();
        var accountController = new AccountController(mockUserValidation.Object, mockUserService.Object);
        var userToSend = new RegisterViewModel()
        {
            Email = "example@example.com",
            FirstName = "Test",
            LastName = "Test",
            NickName = "Test",
            Age = 18,
            Password = "123456A1",
            PasswordConfirm = "123456A1",
            Role = "user"
        };
        mockUserService.Setup(service => service.SaveNewUser(userToSend, userToSend.Password, userToSend.Role).Result)
            .Returns(IdentityResult.Success);

        //Act
        var result = await accountController.Register(userToSend);
        
        //Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Home", redirectToActionResult.ControllerName);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }

    [Fact]
    public async Task RegisterNewUserFails()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var mockUserValidation = new Mock<IUserValidation>();
        var accountController = new AccountController(mockUserValidation.Object, mockUserService.Object);
        var userToSend = new RegisterViewModel()
        {
            Email = "example@example.com",
            FirstName = "Test",
            LastName = "Test",
            NickName = "Test",
            Age = 18,
            Password = "123456A1",
            PasswordConfirm = "123456A1",
            Role = "user"
        };
        mockUserService.Setup(service => service.SaveNewUser(userToSend, userToSend.Password, userToSend.Role).Result)
            .Returns(IdentityResult.Failed());
        
        //Act
        var result = await accountController.Register(userToSend);
        
        //Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult.Model);
        Assert.Equal("Register", viewResult.ViewName);
        Assert.Equal(userToSend, viewResult.Model);
    }
}