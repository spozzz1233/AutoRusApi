using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccess
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.OrderId).HasColumnName("order_id").IsRequired();
            builder.Property(x => x.PartId).HasColumnName("part_id").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName("quantity").IsRequired();
            builder.Property(x => x.ItemPrice).HasColumnName("item_price").IsRequired();

            builder.ToTable("order_items", "public");
        }
    }
}
