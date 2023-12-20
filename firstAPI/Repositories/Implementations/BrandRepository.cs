using firstAPI.DAL;
using firstAPI.Entities;
using firstAPI.Repositories.Interfaces;

namespace firstAPI.Repositories.Implementations
{
    public class BrandRepository : Repository<Brand> , IBrandRepository
    {
        public BrandRepository(AppDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
