
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CarService(ICarRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<Car> Create(CreateCarDto createCarDto)
        {
            if (createCarDto == null) throw new Exception("Not Null");
           
            Car newcar = _mapper.Map<Car>(createCarDto);
            await _repository.Create(newcar);
            await _repository.SaveChangesAsync();
            return newcar;
        }

        public async Task<IQueryable<Car>> GetAll()
        {
           return await _repository.GetAll(OrderByExpression: c => c.ModelYear, isDescending: true);
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
