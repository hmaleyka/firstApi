using firstAPI.DTOs.BrandDtos;
using firstAPI.Entities;

namespace firstAPI.Services.Interfaces
{
    public interface ICarService
    {
        Task<IQueryable<Car>> GetAll();
        Task<Car> GetById(int id);
        Task<Car> Create(CreateCarDto createCarDto);
    }
}
