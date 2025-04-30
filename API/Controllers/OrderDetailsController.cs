using AutoMapper;
using Common.Interfaces;
using DTOs.OrderDetailDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IGenericManager<OrderDetail> _orderDetailManager;
        private readonly IMapper _mapper;

        public OrderDetailsController(IGenericManager<OrderDetail> orderDetailManager, IMapper mapper)
        {
            _orderDetailManager = orderDetailManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderDetailManager.GetAllAsync(
                null,
                od => od.Order,
                od => od.Product
            );

            var dtoList = _mapper.Map<List<OrderDetailDto>>(result.Data);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _orderDetailManager.GetAllAsync(
                od => od.Id == id,
                od => od.Order,
                od => od.Product
            );

            var orderDetail = result.Data.FirstOrDefault();
            if (orderDetail == null)
                return NotFound();

            var dto = _mapper.Map<OrderDetailDto>(orderDetail);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDetailDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderDetail = _mapper.Map<OrderDetail>(dto);
            await _orderDetailManager.AddAsync(orderDetail);

            return CreatedAtAction(nameof(GetById), new { id = orderDetail.Id }, orderDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderDetailDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID uyuşmuyor.");

            var updated = _mapper.Map<OrderDetail>(dto);
            await _orderDetailManager.UpdateAsync(updated);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _orderDetailManager.GetAllAsync(x=>x.Id == id);
            if (existing.Data == null)
                return NotFound();

            await _orderDetailManager.DeleteAsync(existing.Data.FirstOrDefault());
            return NoContent();
        }
    }
}
