using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Ecommerce.Models
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCart");
            builder.HasKey(i => i.ID);
            builder.Property(i => i.ID).ValueGeneratedOnAdd();
            //builder.Property(i => i.ProductId).IsRequired();
            //builder.Property(i => i.UnitPrice).IsRequired();
            //builder.Property(i => i.Quantity).IsRequired();
            //builder.Property(i => i.Discount).IsRequired();
            //builder.Property(i => i.Total).IsRequired();
            //builder.Property(p => p.NameAR).IsRequired().HasMaxLength(500);
            //builder.Property(p => p.NameEN).IsRequired().HasMaxLength(500);
            builder.Property(i => i.IsDeleted).IsRequired().HasDefaultValue(false); ;

        }
    }
}
