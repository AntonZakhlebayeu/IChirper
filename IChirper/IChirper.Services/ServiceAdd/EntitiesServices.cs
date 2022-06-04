using IChirper.Controllers.Services.Classes;
using IChirper.Controllers.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace IChirper.Controllers.ServiceAdd;

public static class EntitiesService
{
    public static void AddEntitiesServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>()
            .AddScoped<IRoleService, RoleService>();
    }
}