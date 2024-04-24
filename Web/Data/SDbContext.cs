using Microsoft.EntityFrameworkCore;
using Web.DataAccess;
using Web.Models;

namespace Web.Data
{
    public class SDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Parts> Parts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        public SDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new OrdersMap());
            modelBuilder.ApplyConfiguration(new PartsMap());
    
        }

    }
}
