using Games.Services;
using Games.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpPost()]
        public async Task<ActionResult<CategoryDto>> Add([FromBody] CategoryDto dto)
        {
            var entity = await _categoryService.Add(dto);
            return Created(entity.Id.ToString(), entity);
        }

        [HttpPut()]
        public async Task<ActionResult<CategoryDto>> Update([FromBody] CategoryDto dto)
        {
            await _categoryService.Update(dto);
            return Ok();
        }

        [HttpDelete()]
        public async Task<ActionResult<CategoryDto>> Remove(int id)
        {
            await _categoryService.Remove(id);
            return Ok();
        }
    }
}
