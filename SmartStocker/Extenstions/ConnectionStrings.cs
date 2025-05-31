using AutoMapper;
using SmartStocker.Abscrations;
using SmartStocker.Controllers;
using SmartStocker.Helpers;
using SmartStocker.Models;
using SmartStocker.Services;
using System.Net;

namespace SmartStocker.Extenstions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Connections>(configuration.GetSection("ConnectionStrings"));
            services.AddDbContext<AppDbContext>();
            services.AddScoped<ProductService>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
