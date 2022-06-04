using IChirper.Controllers;
using IChirper.Controllers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using static IChirper.Controllers.Tests.AccountControllerTests.GetMockData;

namespace IChirper.Controllers.Tests.AccountControllerTests;

public class LoginTest
{
    [Fact]
    public void LoginViewNotNull()
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
    public async Task SendToLoginInvalidUser()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var mockUserValidation = new Mock<IUserValidation>();
        var accountController = new AccountController(mockUserValidation.Object, mockUserService.Object);
        var userToSend = GetTestLoginViewModel();
        
        accountController.ModelState.AddModelError("LoginViewModel", "Email field must be filled.");
        
        //Act
        var result = await accountController.Login(userToSend) as ViewResult;
        
        //Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult.Model);
        Assert.Equal("Login", viewResult.ViewName);
        Assert.Equal(userToSend, viewResult.Model);
    }

    [Fact]
    public async Task LoginNewUserSuccess()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var mockUserValidation = new Mock<IUserValidation>();
        var accountController = new AccountController(mockUserValidation.Object, mockUserService.Object);
        var userToSend = GetTestLoginViewModel();
        
        mockUserValidation.Setup(validation => validation.IsUserNullOrBlocked(userToSend.Email!)).Returns(false);
        mockUserService.Setup(service => service.GetUserByEmail(userToSend.Email!).Result)
            .Returns(GetTestUser().Result);
        mockUserService.Setup(service => service.LoginUser(userToSend).Result).Returns(SignInResult.Success);
        mockUserService.Setup(service => service.Save()).Returns(ValueTask.CompletedTask);
        
        //Act
        var result = await accountController.Login(userToSend);
        
        //Arrange
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Home", redirectToActionResult.ControllerName);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }

    [Fact]
    public async Task SendToLoginNullOrBlockedUser()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var mockUserValidation = new Mock<IUserValidation>();
        var accountController = new AccountController(mockUserValidation.Object, mockUserService.Object);
        var userToSend = GetTestLoginViewModel();
        
        mockUserValidation.Setup(validation => validation.IsUserNullOrBlocked(userToSend.Email!)).Returns(true);

        //Act
        var result = await accountController.Login(userToSend);
        
        //Arrange
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Home", redirectToActionResult.ControllerName);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }

    [Fact]
    public async Task LoginNewUserFails()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var mockUserValidation = new Mock<IUserValidation>();
        var accountController = new AccountController(mockUserValidation.Object, mockUserService.Object);
        var userToSend = GetTestLoginViewModel();
        
        mockUserValidation.Setup(validation => validation.IsUserNullOrBlocked(userToSend.Email!)).Returns(false);
        mockUserService.Setup(service => service.GetUserByEmail(userToSend.Email!).Result)
            .Returns(GetTestUser().Result);
        mockUserService.Setup(service => service.LoginUser(userToSend).Result).Returns(SignInResult.Failed);

        //Act
        var result = await accountController.Login(userToSend);
        
        //Arrange
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal("Login", viewResult.ViewName);
        Assert.Equal(userToSend, viewResult.Model);
    }

    [Fact]
    public async Task LogoutDeletedUser()
    {
        const string email = "example@example.com";
        
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var mockUserValidation = new Mock<IUserValidation>();
        var accountController = new AccountController(mockUserValidation.Object, mockUserService.Object);

        mockUserValidation.Setup(validation => validation.IsUserNull(email)).Returns(true);
        mockUserService.Setup(service => service.LogoutUser()).Returns(ValueTask.CompletedTask);

        //Act
        accountController.ControllerContext = GetMockControllerContext();
        var result = await accountController.Logout();
        
        //Arrange
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Home", redirectToActionResult.ControllerName);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }

    [Fact]
    public async Task LogoutUser()
    {
        const string email = "example@example.com";
        
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var mockUserValidation = new Mock<IUserValidation>();
        var accountController = new AccountController(mockUserValidation.Object, mockUserService.Object);

        mockUserValidation.Setup(validation => validation.IsUserNull(email)).Returns(false);
        mockUserService.Setup(service => service.GetUserByEmail(email).Result).Returns(GetTestUser().Result);
        mockUserService.Setup(service => service.LogoutUser()).Returns(ValueTask.CompletedTask);
        
        //Act
        accountController.ControllerContext = GetMockControllerContext();
        var result = await accountController.Logout();
        
        //Arrange
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Home", redirectToActionResult.ControllerName);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }
}