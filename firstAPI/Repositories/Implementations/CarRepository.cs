using firstAPI.DAL;
using firstAPI.Entities;
using firstAPI.Repositories.Interfaces;

namespace firstAPI.Repositories.Implementations
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
