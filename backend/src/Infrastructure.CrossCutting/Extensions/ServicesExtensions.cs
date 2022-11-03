using Application.Services;
using Application.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CrossCutting.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IGarageService, GarageService>();
        serviceCollection.AddScoped<IUserService, UserService>();

        return serviceCollection;
    }
}