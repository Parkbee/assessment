namespace Data.Models.Garage.Spot;

public class GarageSpotModel : ModelBase
{
    public string Identifier { get; set; }
    public string Details { get; set; }
    public bool IsAvailable { get; set; }
    public GarageModel Garage { get; set; }
}