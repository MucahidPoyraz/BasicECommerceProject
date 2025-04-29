namespace Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // Navigation
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
