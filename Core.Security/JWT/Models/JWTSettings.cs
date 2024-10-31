using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.JWT.Models
{
    public class JWTSettings
    {
        public required string Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public int DurationInMinutes { get; set; }
    }
    public class JwtTokenRequestModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public List<string> Roles { get; set; } = [];
    }

    public class JwtTokenResponseModel
    {
        public required string Token { get; set; }
    }
}
