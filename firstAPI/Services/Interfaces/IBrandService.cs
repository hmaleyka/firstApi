using firstAPI.DTOs.CategoryDtos;
using firstAPI.Entities;

namespace firstAPI.Services.Interfaces
{
    public interface IBrandService
    {

        Task<IQueryable<Brand>> GetAll();
        Task<Brand> GetById(int id);

        Task <Brand> Create(CreateBrandDto createBrandDto);
    }
}
