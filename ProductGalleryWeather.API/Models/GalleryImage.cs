using System.ComponentModel.DataAnnotations;

namespace ProductGalleryWeather.API.Models
{
    public class GalleryImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string SrcUrl { get; set; } = null!;
        [MaxLength(100)]
        public string? Alt { get; set; }
    }
}
