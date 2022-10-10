using Microsoft.EntityFrameworkCore;

namespace ApI.Data
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext()
        {
        }

        public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
        : base(options)
        {
        }

        public DbSet<Garage> Garages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}