using Data.Repositories.Context;
using Data.Repositories.UoW;
using Infrastructure.CrossCutting.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CrossCutting.Extensions;

public static class RepositoriesExtensions
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        return serviceCollection;
    }

    public static IServiceCollection AddDatabaseContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var settings = configuration.GetSection("Storage:SqlServer").Get<SqlServerSettings>();
        serviceCollection.AddDbContext<ParkBeeDbContext>(options => options.UseSqlServer(settings.ConnectionString));
        
        return serviceCollection;
    }
}