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
    }
}
