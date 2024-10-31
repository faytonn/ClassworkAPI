using Microsoft.AspNetCore.Identity;

namespace Classwork.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public required string FullName { get; set; }
    }
}
