using IChirper.Controllers.Services.Classes;
using IChirper.Controllers.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IChirper.Controllers.ServiceAdd;

public static class ValidationServices
{
    public static void AddValidation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserValidation, UserValidationService>();
    }
}