

using Microsoft.AspNetCore.Identity;

namespace BarberConnect.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}