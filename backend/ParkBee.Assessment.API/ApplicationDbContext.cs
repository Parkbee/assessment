using Microsoft.EntityFrameworkCore;

namespace ParkBee.Assessment.API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Garage> Garages { get; set; }
    }

    public class Garage
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}