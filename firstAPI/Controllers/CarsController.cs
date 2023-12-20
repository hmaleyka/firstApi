using firstAPI.DAL;
using firstAPI.Entities;
using firstAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

      
        private readonly IRepository<Car> _repository;

        public CarsController( IRepository<Car> repository)
        {
           
            _repository = repository;
        }
       
        [HttpGet]    
        public async Task<IActionResult> GetAll()
        {
            var cars = await _repository.GetAll();

            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cars = await _repository.GetByIdAsync(id);
            if (cars == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpPost] 
        public async Task<IActionResult> Create([FromForm] Car car)
        {
            Car cars = new Car()
            {
                color = car.color,
                brand = car.brand,
                Name = car.Name
                

            };
            await _repository.Create(car);
            await _repository.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, car);
        }
        [HttpPut] 
        public async Task<IActionResult> Update (int id , string name, string description, DateTime time, string brand, string color)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

            var cars = await _repository.GetByIdAsync(id);

            if (cars == null) return StatusCode(StatusCodes.Status404NotFound);

            cars.Name= name;
            cars.Description= description;
            cars.ModelYear = time;
            _repository.Update(cars);
            await _repository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, cars);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var cars = _repository.GetByIdAsync(id);
            //await _repository.DeleteAsync(cars);
            await _repository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, cars);

        }
    }
}
