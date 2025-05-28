using SmartStocker.Models;
using System.Net;

namespace SmartStocker.Extenstions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Connections>(configuration.GetSection("ConnectionStrings"));
            services.AddDbContext<AppDbContext>();
            return services;
        }
    }
}
