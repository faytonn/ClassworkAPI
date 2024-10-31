using Classwork.Application.DTOs;
using Classwork.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryManager;

        public CategoriesController(ICategoryService CategoryService)
        {
            _categoryManager = CategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByPage([FromQuery] PageRequest pageRequest)
        {
            var CategoryList = await _categoryManager.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);

            return Ok(CategoryList);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return NotFound();

            var Category = await _categoryManager.GetAsync(id.Value);

            return Ok(Category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryCreateDTO createDto)
        {
            var createdCategory = await _categoryManager.AddAsync(createDto);

            return Ok(createdCategory);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put(int? id, [FromBody] CategoryUpdateDTO updateDto)
        {
            if (id == null) return NotFound();

            var updatedCategory = await _categoryManager.UpdateAsync(id.Value, updateDto);

            return Ok(updatedCategory);
        }
    }
}
