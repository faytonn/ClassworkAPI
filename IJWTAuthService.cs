using System;

public interface IJwtAuthService
{
    Task<JwtTokenResponseModel> CreateToken(JwtTokenRequestModel model);
}

