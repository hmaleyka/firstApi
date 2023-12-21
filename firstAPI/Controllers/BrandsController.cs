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
        public async Task<IActionResult> Update(int id, [FromForm] UpdateBrandDto updateBrandDto)
        {
            var brands = await _service.Update(id, updateBrandDto);
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status200OK);

        }
    }
}
