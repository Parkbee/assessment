using System;
using System.Collections.Generic;
using System.Linq;
using ApI.Data;
using ApI.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.AddSecurityDefinition(ApiKeyAuthenticationOptions.DefaultScheme, new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = ApiKeyAuthenticationOptions.HeaderName,
        Type = SecuritySchemeType.ApiKey
    });

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = ApiKeyAuthenticationOptions.DefaultScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddScoped<ApiKeyAuthenticationHandler>();

builder.Services.AddDbContext<ParkingDbContext>(options => options.UseInMemoryDatabase("parkbee"));

builder.Services.AddAuthentication(ApiKeyAuthenticationOptions.DefaultScheme)
    .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.DefaultScheme,
        null);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AddSeedData(app);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


static void AddSeedData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var parkingDbContext = scope.ServiceProvider.GetService<ParkingDbContext>();

    parkingDbContext.Garages.AddRange(Enumerable.Range(0, 10).Select(x => new Garage
    {
        Id = Guid.NewGuid(),
        Name = $"Garage {Guid.NewGuid()}",
        Doors = new List<Door>()
        {
            new Door
            {
                Id = Guid.NewGuid(),
                Description = $"Door {Guid.NewGuid()}",
                DoorType = DoorType.Entry
            },
            new Door
            {
                Id = Guid.NewGuid(),
                Description = $"Door {Guid.NewGuid()}",
                DoorType = DoorType.Exit
            },
            new Door
            {
                Id = Guid.NewGuid(),
                Description = $"Door {Guid.NewGuid()}",
                DoorType = DoorType.Pedestrian
            }
        }
    }));
    parkingDbContext.Users.AddRange(Enumerable.Range(0, 20).Select(x => new User()
    {
        Id = Guid.NewGuid(),
        PartnerId = "partner-1"
    }));

    parkingDbContext.SaveChanges();
}