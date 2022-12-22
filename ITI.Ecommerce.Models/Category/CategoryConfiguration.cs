using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Ecommerce.Models
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).IsRequired();
            builder.Property(p => p.NameAR).IsRequired().HasMaxLength(500);
            builder.Property(p => p.NameEN).IsRequired().HasMaxLength(500);
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);

        }
    }
}
