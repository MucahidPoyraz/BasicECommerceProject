using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL.Context.EF
{
    public class BECPContext : DbContext
    {
        public BECPContext(DbContextOptions<BECPContext> context) : base(context)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
