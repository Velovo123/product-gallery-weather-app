using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductGalleryWeather.API.Models;
using System.Linq.Expressions;

namespace ProductGalleryWeather.API.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts(Expression<Func<Product, bool>>? filter = null);
        Task<Product> GetProduct(Expression<Func<Product, bool>>? filter = null, bool tracked = true);
        Task CreateProduct(Product product);
        Task RemoveProduct(Product product);
        Task Save();
    }
}
