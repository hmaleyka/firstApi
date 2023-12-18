using firstAPI.DAL;
using firstAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private AppDbContext _dbcontext;

        public ColorsController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get()
        {
            List<Color> colors = await _dbcontext.colors.ToListAsync();

            return StatusCode(StatusCodes.Status200OK, colors);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var colors = await _dbcontext.colors.FirstOrDefaultAsync(c => c.Id == id);
            if (colors == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, colors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            await _dbcontext.colors.AddAsync(color);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, color);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

            var colors = await _dbcontext.colors.FirstOrDefaultAsync(c => c.Id == id);

            if (colors == null) return StatusCode(StatusCodes.Status404NotFound);

            colors.colorName = name;
               await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, colors);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var colors = _dbcontext.colors.FirstOrDefault(c => c.Id == id);
            _dbcontext.colors.Remove(colors);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, colors);

        }
    }
}
