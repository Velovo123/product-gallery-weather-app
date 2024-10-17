using Microsoft.AspNetCore.Identity;

namespace ProductGalleryWeather.API.Services.IServices
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user, IList<string> roles);
    }
}
