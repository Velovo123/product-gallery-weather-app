using Microsoft.EntityFrameworkCore;
using ProductGalleryWeather.API.Data;
using ProductGalleryWeather.API.Models;
using ProductGalleryWeather.API.Repository.IRepository;
using System.Linq.Expressions;

namespace ProductGalleryWeather.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task CreateProduct(Product product)
        {
            await _db.Products.AddAsync(product);
            await Save();
        }

        public async Task<IEnumerable<Product>> GetAllProducts(Expression<Func<Product, bool>>? filter = null)
        {
            IQueryable<Product> query = _db.Products;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<Product> GetProduct(Expression<Func<Product, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<Product> query = _db.Products;
            if(!tracked)
            {
                query = query.AsNoTracking();
            }

            if(filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveProduct(Product product)
        {
            _db.Remove(product);
            await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
