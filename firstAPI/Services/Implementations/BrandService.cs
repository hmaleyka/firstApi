

using AutoMapper;

namespace firstAPI.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Brand> Create(CreateBrandDto createBrandDto)
        {
            if (createBrandDto == null) throw new Exception("Not Null");

            Brand brand = new Brand()
            {
                brandName = createBrandDto.Name,
            };
            await  _repository.Create(brand);
            await _repository.SaveChangesAsync();
            return brand;
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

        public async Task<Brand> Update(int id, UpdateBrandDto updatebranddto)
        {
            if (id <= 0) throw new Exception("Bad Request");

            var existbrand =await _repository.GetByIdAsync(id);
            //_mapper.Map(existbrand, updatebranddto);
            existbrand.brandName= updatebranddto.Name;
            _repository.Update(existbrand);
            await _repository.SaveChangesAsync();
            return existbrand;

        }
        public async Task<Brand> Delete(int id)
        {
            var brand = await _repository.GetByIdAsync(id);
            _repository.Delete(brand);
            await _repository.SaveChangesAsync();
            return brand;
        }
    }
}
