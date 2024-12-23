using Net_Core_API_Store.Implementations;
using Net_Core_API_Store.Interfaces;

namespace Net_Core_API_Store
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductoRepository, ProductoRepository>();
            return services;
        }
    }
}
