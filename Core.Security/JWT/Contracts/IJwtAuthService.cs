using Core.Security.JWT.Models;

namespace Core.Security.JWT.Contracts
{
    public interface IJwtAuthService
    {
        Task<JwtTokenResponseModel> CreateToken(JwtTokenRequestModel model);

    }
}
