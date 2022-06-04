using IChirper.Controllers.Data.Interfaces;
using IChirper.Controllers.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IChirper.Controllers.ServiceAdd;

public static class Repositories
{
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRoleRepository, RoleRepository>();
    }
}