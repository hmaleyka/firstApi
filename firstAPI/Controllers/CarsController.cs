using firstAPI.DAL;
using firstAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private AppDbContext _dbcontext;

        public CarsController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get()
        {
            List<Car> cars = await _dbcontext.cars.Include(c=>c.brand).Include(c=>c.color).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var cars = await _dbcontext.cars.FirstOrDefaultAsync(c=>c.Id==id);
            if (cars == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpPost] 
        public async Task<IActionResult> Create(Car car)
        {
            await _dbcontext.cars.AddAsync(car);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, car);
        }
        [HttpPut] 
        public async Task<IActionResult> Update (int id , string name, string description, DateTime time, string brand, string color)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

            var cars = await _dbcontext.cars.FirstOrDefaultAsync(c=>c.Id==id);

            if (cars == null) return StatusCode(StatusCodes.Status404NotFound);

            cars.Name= name;
            cars.Description= description;
            cars.ModelYear = time;
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, cars);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var cars = _dbcontext.cars.FirstOrDefault(c => c.Id == id);
            _dbcontext.cars.Remove(cars);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, cars);

        }
    }
}
