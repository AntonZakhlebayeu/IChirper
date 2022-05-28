using IChirper.Services.Classes;
using IChirper.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace IChirper.ServiceAdd;

public static class EntitiesService
{
    public static void AddEntitiesServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>()
            .AddScoped<IRoleService, RoleService>();
    }
}