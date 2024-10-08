using AutoMapper;
using ProductGalleryWeather.API.Models;
using ProductGalleryWeather.API.Models.Dto;

namespace ProductGalleryWeather.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<ImageUrlResolver>());
        }
    }
}
