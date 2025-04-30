using AutoMapper;
using Common.Interfaces;
using DTOs.ProductDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericManager<Product> _productManager;
        private readonly IMapper _mapper;
        public ProductController(IGenericManager<Product> productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productManager.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productManager.GetAllAsync(x => x.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productManager.AddAsync(_mapper.Map<Product>(product));
            return CreatedAtAction(nameof(GetById), new { id = product }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto product)
        {
            if (id != product.Id)
                return BadRequest("ID uyuşmuyor.");

            await _productManager.UpdateAsync(_mapper.Map<Product>(product));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productManager.GetAllAsync(x => x.Id == id);
            if (product == null)
                return NotFound();

            await _productManager.DeleteAsync(product.Data.FirstOrDefault());
            return NoContent();
        }
    }
}
