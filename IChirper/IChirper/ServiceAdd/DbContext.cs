using IChirper.Data;

namespace IChirper.ServiceAdd;

public static class DbContext
{
    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<IChirperDbContext>();
        services.AddDatabaseDeveloperPageExceptionFilter();
    }
}