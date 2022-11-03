using System;
using Data.Models.Garage.Spot;
using Data.Models.User;

namespace Data.Models.ParkingSession;

public class ParkingSessionModel : ModelBase
{
    public GarageSpotModel GarageSpot { get; set; }
    public UserModel User { get; set; }
    public DateTime Start { get; set; }
    public DateTime Stop { get; set; }

    public bool IsActive { get; set; }
}