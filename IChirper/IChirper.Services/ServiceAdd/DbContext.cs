using IChirper.Data;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IChirper.ServiceAdd;

public static class DbContext
{
    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<IChirperDbContext>();
        services.AddDatabaseDeveloperPageExceptionFilter();
    }
}