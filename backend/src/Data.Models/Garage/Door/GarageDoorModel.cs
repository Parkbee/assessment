namespace Data.Models.Garage.Door;

public class GarageDoorModel : ModelBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string IpAddress { get; set; }
    public bool IsOpen { get; set; }
    public GarageModel Garage { get; set; }
}