using System.ComponentModel.DataAnnotations;

namespace ProductGalleryWeather.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string Author { get; set; } = null!;
        [Required]
        [Range(0,10000, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(100)]
        public string? ImageUrl { get; set; }
    }
}
