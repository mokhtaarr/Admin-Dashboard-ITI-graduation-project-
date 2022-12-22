using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Ecommerce.Models
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();

            builder.Property(p => p.NameAR).HasMaxLength(500).IsRequired();

            builder.Property(p => p.NameEN).HasMaxLength(500).IsRequired();

            builder.Property(p => p.Brand).HasMaxLength(500).IsRequired();

            builder.Property(p => p.Description).HasMaxLength(5000).IsRequired();

            builder.Property(p => p.CategoryID).IsRequired();

            builder.Property(p => p.Quantity).IsRequired();

            builder.Property(p => p.UnitPrice).IsRequired();

            builder.Property(p => p.Discount).IsRequired();

            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
        }

    }
}
