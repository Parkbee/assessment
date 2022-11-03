using System.Collections.Generic;
using Data.Models.Garage.Door;
using Data.Models.Garage.Spot;

namespace Data.Models.Garage;

public class GarageModel : ModelBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public IList<GarageDoorModel> Doors { get; set; }
    public IList<GarageSpotModel> Spots { get; set; }
}