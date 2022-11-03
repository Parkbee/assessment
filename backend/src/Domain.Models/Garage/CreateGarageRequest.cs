using System.Collections.Generic;
using Domain.Models.Garage.Door;
using Domain.Models.Garage.Spot;

namespace Domain.Models.Garage;

public record CreateGarageRequest(
    string Name, 
    string Description,
    string Address,
    IReadOnlyCollection<CreateGarageDoorRequest> Doors,
    IReadOnlyCollection<UpsertGarageSpotRequest> Spots);