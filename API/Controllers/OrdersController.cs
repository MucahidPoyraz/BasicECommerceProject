using AutoMapper;
using Common.Interfaces;
using DTOs.OrderDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IGenericManager<Order> _orderManager;
        private readonly IGenericManager<OrderDetail> _orderDetailManager;
        private readonly IMapper _mapper;

        public OrdersController(IGenericManager<Order> orderManager, IMapper mapper, IGenericManager<OrderDetail> orderDetailManager)
        {
            _orderManager = orderManager;
            _mapper = mapper;
            _orderDetailManager = orderDetailManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderManager.GetAllAsync(
                null,
                o => o.Customer,
                o => o.OrderDetails,
                o => o.OrderDetails.Select(od => od.Product)
            );

            var dto = _mapper.Map<List<OrderDto>>(orders.Data);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orders = await _orderManager.GetAllAsync(
                o => o.Id == id,
                o => o.Customer,
                o => o.OrderDetails,
                o => o.OrderDetails.Select(od => od.Product)
            );

            var order = orders.Data.FirstOrDefault();
            if (order == null)
                return NotFound();

            var dto = _mapper.Map<OrderDto>(order);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Order order = new Order();
            order.OrderDate = createDto.OrderDate;
            order.CreatedDate = DateTime.Now;
            order.CustomerId = createDto.CustomerId;
            order.IsDeleted = false;

            var createdOrder = await _orderManager.AddAsync(order);



            foreach (var item in createDto.OrderDetails)
            {
                item.OrderId = createdOrder.Data.Id;
               
                await _orderDetailManager.AddAsync(_mapper.Map<OrderDetail>(item));
            }

         

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest("ID uyuşmuyor.");

            var order = _mapper.Map<Order>(updateDto);
            await _orderManager.UpdateAsync(order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var orderResult = await _orderManager.GetAllAsync(x => x.Id == id);
            if (orderResult.Data == null)
                return NotFound();

            await _orderManager.DeleteAsync(orderResult.Data.FirstOrDefault());
            return NoContent();
        }

        // İsteğe bağlı: Belirli müşteriye ait siparişler
        [HttpGet("ByCustomer/{customerId}")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var orders = await _orderManager.GetAllAsync(
                o => o.CustomerId == customerId,
                o => o.OrderDetails,
                o => o.OrderDetails.Select(od => od.Product)
            );

            var dto = _mapper.Map<List<OrderDto>>(orders.Data);
            return Ok(dto);
        }
    }
}
