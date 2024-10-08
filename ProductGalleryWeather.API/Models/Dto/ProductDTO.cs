using System.ComponentModel.DataAnnotations;

namespace ProductGalleryWeather.API.Models.Dto
{
    public class ProductDTO
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Author { get; set; } = null!;
        [Required]
        [Range(0, 10000, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;
    }
}
