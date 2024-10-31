using Core.Security.JWT.Contracts;
using Core.Security.JWT.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Security
{
    public static class SecurityServiceRegistration
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtAuthService, JwtAuthManager>();

            return services;
        }
    }
}
