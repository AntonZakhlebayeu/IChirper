using IChirper.Services.Classes;
using IChirper.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IChirper.ServiceAdd;

public static class ValidationServices
{
    public static void AddValidation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserValidation, UserValidationService>();
    }
}