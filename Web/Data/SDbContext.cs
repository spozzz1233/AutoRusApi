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
            //Код выполняет конфигурацию модели данных для создания базы данных.
            base.OnModelCreating(modelBuilder);
            //Метод ApplyConfiguration() применяет указанную конфигурацию для соответствующей сущности модели данных.
            //Это позволяет настроить свойства каждой сущности, установить соответствующие ограничения, реализовать связи между сущностями и др.
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new OrdersMap());
            modelBuilder.ApplyConfiguration(new PartsMap());
    
        }

    }
}
