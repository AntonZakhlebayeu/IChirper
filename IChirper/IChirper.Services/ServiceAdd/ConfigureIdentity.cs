using IChirper.Controllers.Data;
using IChirper.Controllers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace IChirper.Controllers.ServiceAdd;

public static class ConfigureIdentity
{
    public static void AddIdentity(this IServiceCollection _service)
    {
        _service.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IChirperDbContext>();
    }
}