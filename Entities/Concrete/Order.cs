namespace Entities.Concrete
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        // Navigation
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
