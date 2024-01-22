using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models;

namespace Web.DataAccess
{
    public class CustomerMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.MidName).HasColumnName("mid_name").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.DateOfBirth).HasColumnName("date_of_birth").IsRequired();
            builder.Property(x => x.Phonenum).HasColumnName("phonenum").HasMaxLength(10).IsRequired();
            builder.ToTable("customers", "public");
        }
    }
}
