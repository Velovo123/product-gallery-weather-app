namespace ProductGalleryWeather.API.Models.Dto
{
    public class RegisterModelDTO
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
