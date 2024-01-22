using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccess
{
    public class OrdersMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired();
            builder.Property(x => x.EmployeeId).HasColumnName("employee_id").IsRequired();
            builder.Property(x => x.OrderDate).HasColumnName("order_date").IsRequired();
           
            builder.ToTable("orders", "public");
        }
    }
}
