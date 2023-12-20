using firstAPI.DTOs.CategoryDtos;
using firstAPI.Entities;
using firstAPI.Repositories.Interfaces;
using firstAPI.Services.Interfaces;

namespace firstAPI.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;

        public BrandService(IBrandRepository repository )
        {
            _repository = repository;
        }

        public Task Create(CreateBrandDto createBrandDto)
        {
            if (createBrandDto == null) throw new Exception();
        }

        public async Task<IQueryable<Brand>> GetAll()
        {
            return await _repository.GetAll(OrderByExpression: c=>c.brandName, isDescending:true);
        }

        public async Task<Brand> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");

            var brand = await _repository.GetByIdAsync(id);
            if (brand == null) throw new Exception("Not Found");
            return brand;
        }
    }
}
