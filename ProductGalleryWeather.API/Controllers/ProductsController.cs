using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductGalleryWeather.API.Models.Dto;
using ProductGalleryWeather.API.Repository.IRepository;

namespace ProductGalleryWeather.API.Controllers
{

    [ApiController]
    [Route("api/products")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository productRepository, IMapper mapper )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAllProducts();
            var productDtos = _mapper.Map<List<ProductDTO>>(products);

            return Ok(productDtos);
        }

        [HttpGet("{id:int}")]
        public Task<IActionResult> GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
