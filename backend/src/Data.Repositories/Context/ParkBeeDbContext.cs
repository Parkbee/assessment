using System.Reflection;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Context;

public class ParkBeeDbContext : DbContext
{
    public ParkBeeDbContext(DbContextOptions<ParkBeeDbContext> dbContextOptions)
        : base(dbContextOptions) => Database.EnsureCreated();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(), 
            type => type
                .GetInterfaces()
                .Any(baseInterface => 
                    baseInterface.IsGenericType &&
                    baseInterface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) &&
                    typeof(ModelBase).IsAssignableFrom(baseInterface.GenericTypeArguments[0])));
        
        base.OnModelCreating(modelBuilder);
    }
}