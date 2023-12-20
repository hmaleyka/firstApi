
using firstAPI.DTOs.CarDtos;
using firstAPI.Entities;
using firstAPI.Repositories.Interfaces;
using firstAPI.Services.Interfaces;
using System.Drawing;

namespace firstAPI.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }


        public Task<Car> Create(CreateCarDto createCarDto)
        {
            if (createCarDto == null) throw new Exception("Not Null");
            Car cars = new Car()
            {
                Name = createCarDto.Name,
                Description = createCarDto.Description,
                ModelYear = createCarDto.ModelYear,
                DailyPrice = createCarDto.Dailyprice,
                ColorID = createCarDto.ColorId,
                BrandId = createCarDto.BrandId,

            };
            await _repository.Create(cars);
            await _repository.SaveChangesAsync();
            return cars;
        }

        public async Task<IQueryable<Car>> GetAll()
        {
           return await _repository.GetAll();
        }

        public async Task<Car> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");

            var car = await _repository.GetByIdAsync(id);
            if (car == null) throw new Exception("Not Found");
            return car;
        }
    }
}
