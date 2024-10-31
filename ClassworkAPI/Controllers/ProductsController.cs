using Classwork.Application.DTOs;
using Classwork.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Classwork.Application.DTOs.ProductDTO;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByPage([FromQuery] PageRequest pageRequest)
        {
            var studentList = await _productService.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);

            return Ok(studentList);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return NotFound();

            var student = await _productService.GetAsync(id.Value);

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreateDto createDto)
        {
            var createdStudent = await _productService.AddAsync(createDto);

            return Ok(createdStudent);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put(int? id, [FromBody] ProductUpdateDto updateDto)
        {
            if (id == null) return NotFound();

            var updatedStudent = await _productService.UpdateAsync(id.Value, updateDto);

            return Ok(updatedStudent);
        }
    }
}

