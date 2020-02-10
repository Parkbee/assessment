using ParkBee.Assessment.API;

public class GarageController
{
    private ApplicationDbContext _context;

    public GarageController()
    {
        _context = new ApplicationDbContext();
    }
}