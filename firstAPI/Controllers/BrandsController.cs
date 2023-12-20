using firstAPI.DAL;

namespace firstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
   
        private readonly IBrandRepository _repository;
        private readonly IBrandService _service;

        public BrandsController(IBrandRepository repository, IBrandService service)
        {
         
            _repository = repository;
            _service = service;
        }

        [HttpGet]    
        public async Task<IActionResult> GetAll()
        {
            var brands = await _service.GetAll();

            return StatusCode(StatusCodes.Status200OK, brands);
        }

        [HttpGet("{id}")]
       
        public async Task<IActionResult> GetById(int id)
        {
            var brands = await _service.GetById(id);

            return StatusCode(StatusCodes.Status200OK, brands);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateBrandDto brandDto)
        {
            var brand =  await  _service.Create(brandDto);

            return StatusCode(StatusCodes.Status201Created, brand);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

            var brands = await _repository.GetByIdAsync(id);

            if (brands == null) return StatusCode(StatusCodes.Status404NotFound);

            brands.brandName = name;
            _repository.Update(brands);
            await _repository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var brands = _repository.GetByIdAsync(id);
            //await _repository.Remove(brands);
            await _repository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, brands);

        }
    }
}
