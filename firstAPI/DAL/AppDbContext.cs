using firstAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace firstAPI.DAL
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Car> cars { get; set; }
        public DbSet<Color > colors { get; set; }
        public DbSet<Brand> brands { get; set; }
    }
}
