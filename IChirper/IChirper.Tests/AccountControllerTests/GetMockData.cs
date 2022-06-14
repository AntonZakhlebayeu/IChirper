using System.Security.Claims;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IChirper.Controllers.Tests.AccountControllerTests;

public static class GetMockData
{
    public static async Task<UserViewModel> GetTestUser()
    {
        return await Task.Run(() => new UserViewModel { Email = "example@example.com", FirstName = "Test", LastName = "Test", NickName = "BlackM", Age = 18, RegisterDate = new DateTime(2022, 2, 24), LastLoginDate = new DateTime(2022, 2, 24), Status = "Active User" });
    }

    public static ControllerContext GetMockControllerContext()
    {
        const string email = "example@example.com";
        
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

        return context;
    }

    public static LoginViewModel GetTestLoginViewModel()
    {
        return new LoginViewModel()
        {
            Email = "example@example.com",
            Password = "123456A1"
        };
    }

    public static List<PageViewModel> GetTestPage()
    {
        return new List<PageViewModel>()
        {
            new() {Id = 1, Author = "Test", Title = "Test", PageDescription = "Test", CreatedAt = "Test", UpdatedAt = "Test"},
            new() {Id = 2, Author = "Test", Title = "Test", PageDescription = "Test", CreatedAt = "Test", UpdatedAt = "Test"},
            new() {Id = 3, Author = "Test", Title = "Test", PageDescription = "Test", CreatedAt = "Test", UpdatedAt = "Test"},
            new() {Id = 4, Author = "Test", Title = "Test", PageDescription = "Test", CreatedAt = "Test", UpdatedAt = "Test"},
        };
    }
}