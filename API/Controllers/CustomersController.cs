using AutoMapper;
using Common.Interfaces;
using DTOs.CustomerDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGenericManager<Customer> _customerManager;
        private readonly IMapper _mapper;

        public CustomerController(IGenericManager<Customer> customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerManager.GetAllAsync();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers.Data);
            return Ok(customerDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerManager.GetAllAsync(x=>x.Id == id);
            if (customer == null)
                return NotFound();

            var dto = _mapper.Map<CustomerDto>(customer.Data.FirstOrDefault());
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Customer>(dto);
            await _customerManager.AddAsync(entity);

            var responseDto = _mapper.Map<CustomerDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, responseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID uyuşmuyor.");

            var existing = await _customerManager.GetAllAsync(x=>x.Id == id);
            if (existing == null)
                return NotFound();

            var updated = _mapper.Map<Customer>(dto);
            await _customerManager.UpdateAsync(updated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerManager.GetAllAsync(x => x.Id == id);
            if (customer == null)
                return NotFound();

            await _customerManager.DeleteAsync(customer.Data.FirstOrDefault());
            return NoContent();
        }
    }
}
