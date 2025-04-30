using DTOs.OrderDetailDtos;

namespace DTOs.OrderDtos
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
