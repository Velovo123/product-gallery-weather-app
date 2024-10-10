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

            // Explicitly include the port for localhost
            var host = request.Host.HasValue ? request.Host.ToString() : "localhost:7199";

            // Ensure the port is included in the host
            if (!host.Contains(":"))
            {
                host += ":7199";  // Ensure port 7199 is included
            }

            var baseUrl = $"{request.Scheme}://{host}{request.PathBase}";
            return $"{baseUrl}{source.ImageUrl}";
        }

    }
}
