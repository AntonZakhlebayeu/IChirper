using IChirper.Data;
using IChirper.Models;
using Microsoft.AspNetCore.Identity;

namespace IChirper.ServiceAdd;

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