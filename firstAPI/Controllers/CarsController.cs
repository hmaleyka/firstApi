
namespace firstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

      
        private readonly IRepository<Car> _repository;
        private readonly ICarService _service;

        public CarsController( IRepository<Car> repository, ICarService service)
        {
           
            _repository = repository;
            _service = service;
        }
       
        [HttpGet]    
        public async Task<IActionResult> GetAll()
        {
            var cars = await _service.GetAll();

            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cars = await _service.GetById(id);  
        
            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpPost] 
        public async Task<IActionResult> Create([FromForm] CreateCarDto createCarDto)
        {
        
            var car = await _service.Create(createCarDto);
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
