using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccess
{
    public class PartsMap : IEntityTypeConfiguration<Parts>
    {
        public void Configure(EntityTypeBuilder<Parts> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.PartName).HasColumnName("part_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasColumnName("price").HasMaxLength(50).IsRequired();
            builder.Property(x => x.StockQuantity).HasColumnName("stock_quantity").IsRequired();

            builder.ToTable("parts", "public");
        }
    }
}