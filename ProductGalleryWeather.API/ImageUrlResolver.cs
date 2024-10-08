using AutoMapper;
using ProductGalleryWeather.API.Models;
using ProductGalleryWeather.API.Models.Dto;

namespace ProductGalleryWeather.API
{
    public class ImageUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImageUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
            return $"{baseUrl}{source.ImageUrl}";
        }
    }
}
