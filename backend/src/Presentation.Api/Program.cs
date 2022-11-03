using Data.Models.Garage;
using Data.Models.Garage.Door;
using Data.Models.Garage.Spot;
using Data.Repositories.UoW;
using Infrastructure.CrossCutting.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddDatabaseContext(builder.Configuration)
    .AddUnitOfWork()
    .AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// AddSeedData(app);
    
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


static async Task AddSeedData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var unitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>();

    for (var index = 0; index < 2; index++)
    {
        await unitOfWork?.GarageRepository.CreateGarageAsync(new GarageModel
        {
            Name = $"Park-{index}",
            Description = "Park One",
            Address = "Fake Street",
            Doors = new List<GarageDoorModel>
            {
                new GarageDoorModel
                {
                    Name = $"Door {index}",
                    Description = "Test",
                    IpAddress = "127.0.0.1",
                    IsOpen = false
                }
            },
            Spots = new List<GarageSpotModel>
            {
                new GarageSpotModel
                {
                    Identifier = $"A - {index}",
                    IsAvailable = true,
                    Details = $"Garage: Park-{index}"
                }
            }
        })!;
    }
    
    unitOfWork?.CompleteAsync();
}