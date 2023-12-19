using firstAPI.DAL;
using firstAPI.DTOs.CategoryDtos;
using firstAPI.Entities;
using firstAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
   
        private readonly IRepository<Brand> _repository;

        public BrandsController( IRepository<Brand> repository)
        {
         
            _repository = repository;
        }

        [HttpGet]
    
        public async Task<IActionResult> GetAll()
        {
            var brands = await _repository.GetAll();

            return StatusCode(StatusCodes.Status200OK, brands);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brands = await _repository.GetByIdAsync(id);
            if (brands == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, brands);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateBrandDto brandDto)
        {
            Brand brand = new Brand()
            {
                brandName = brandDto.Name,
            };
            await _repository.Create(brand);
         await _repository.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, brand);
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
