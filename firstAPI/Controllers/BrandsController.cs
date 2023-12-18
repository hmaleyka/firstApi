using firstAPI.DAL;
using firstAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private AppDbContext _dbcontext;

        public BrandsController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get()
        {
            List<Brand> brands = await _dbcontext.brands.ToListAsync();

            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var brands = await _dbcontext.brands.FirstOrDefaultAsync(c => c.Id == id);
            if (brands == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, brands);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            await _dbcontext.brands.AddAsync(brand);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, brand);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

            var brands = await _dbcontext.brands.FirstOrDefaultAsync(c => c.Id == id);

            if (brands == null) return StatusCode(StatusCodes.Status404NotFound);

            brands.brandName = name;
       
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var brands = _dbcontext.brands.FirstOrDefault(c => c.Id == id);
            _dbcontext.brands.Remove(brands);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, brands);

        }
    }
}
