using Microsoft.EntityFrameworkCore;

namespace ITI.Ecommerce.Models
{
    public static class RelationshipsMapping
    {
        public static void MapRelationships(this ModelBuilder builder)
        {

            //Relation one to many between Category and Product
            builder
               .Entity<Product>()
               .HasOne(i => i.Category)
               .WithMany(i => i.ProductList)
               .HasForeignKey(i => i.CategoryID)
               .IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Relation one to many between Category and ProductImage
            builder
               .Entity<ProductImage>()
               .HasOne(i => i.Product)
               .WithMany(i => i.productImageList)
               .HasForeignKey(i => i.ProductID)
               .IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Relation Many to many between Shopping Cart and Product
            builder
               .Entity<ShoppingCart>()
               .HasMany(i => i.productList)
               .WithMany(i => i.ShoppingCartList);

            //Relation One to One between Shopping Cart and Order
            builder
               .Entity<ShoppingCart>()
              .HasOne(i => i.Order).WithOne(i => i.ShoppingCart);

            //Relation one to many between Customer and Order
            builder
               .Entity<Customer>()
               .HasMany(i => i.orderList).WithOne(i => i.customer)
               .HasForeignKey(i => i.CustomerId)
               .IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasOne(i => i.customer).WithMany(i => i.orderList).HasForeignKey(i => i.CustomerId)
                 .IsRequired().OnDelete(DeleteBehavior.Cascade);
            //Relation One to One between Payment and Order
            builder
               .Entity<Payment>()
              .HasOne(i => i.Order).WithOne(i => i.Payment);
        }
    }
}
