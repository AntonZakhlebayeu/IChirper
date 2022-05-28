using IChirper.Data.Interfaces;
using IChirper.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IChirper.ServiceAdd;

public static class Repositories
{
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRoleRepository, RoleRepository>();
    }
}