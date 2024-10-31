using Classwork.Application.Services.Implementations;
using Classwork.Application.Services.Interfaces;
using Ecom.App.Services.CategoryService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Classwork.Application
{
    public static class AppServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
