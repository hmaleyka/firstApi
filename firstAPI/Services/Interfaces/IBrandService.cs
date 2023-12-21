

namespace firstAPI.Services.Interfaces
{
    public interface IBrandService
    {

        Task<IQueryable<Brand>> GetAll();
        Task<Brand> GetById(int id);

        Task <Brand> Create(CreateBrandDto createBrandDto);
        Task<Brand> Update(int id, UpdateBrandDto updatebranddto);

        Task<Brand> Delete(int id);
    }
}
