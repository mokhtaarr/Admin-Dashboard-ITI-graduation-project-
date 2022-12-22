using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {


        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new ProductImagesConfiguration().Configure(modelBuilder.Entity<ProductImage>());
            new ShoppingCartConfiguration().Configure(modelBuilder.Entity<ShoppingCart>());
            new CustomerConfiguration().Configure(modelBuilder.Entity<Customer>());
            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new PaymentConfiguration().Configure(modelBuilder.Entity<Payment>());
            modelBuilder.MapRelationships();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
