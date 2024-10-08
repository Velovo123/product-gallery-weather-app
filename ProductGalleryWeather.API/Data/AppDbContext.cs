using Microsoft.EntityFrameworkCore;
using ProductGalleryWeather.API.Models;

namespace ProductGalleryWeather.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products {get;set;}
        public DbSet<GalleryImage> GalleryImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id= 1,
                   Title = "Astro Fiction",
                   Author = "John Doe",
                   Price = 19.99m,
                   ImageUrl = "/products/images/astro-fiction.png"
               },
               new Product
               {
                   Id = 2,
                   Title = "Black Dog",
                   Author = "Mary Poppins",
                   Price = 20m,
                   ImageUrl = "/products/images/black-dog.png"
               },
               new Product
               {
                   Id = 3,
                   Title = "Doomed City",
                   Author = "J.D. Salinger",
                   Price = 16.99m,
                   ImageUrl = "/products/images/doomed-city.png"
               },
               new Product
               {
                   Id = 4,
                   Title = "Garden Girl",
                   Author = "F. Scott Fitzgerald",
                   Price = 14.99m,
                   ImageUrl = "/products/images/garden-girl.png"
               },
               new Product
               {
                   Id = 5,
                   Title = "My little Robot",
                   Author = "Jane Austen",
                   Price = 13.99m,
                   ImageUrl = "/products/images/my-little-robot.png"
               },
               new Product
               {
                   Id = 6,
                   Title = "SpaceOdissey",
                   Author = "Harper Lee",
                   Price = 11.99m,
                   ImageUrl = "/products/images/space-odissey.png"
               }
            );
                
        }
    }
}
