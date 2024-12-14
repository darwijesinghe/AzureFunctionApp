using App.Services.Classes;
using App.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.Configurations
{
    /// <summary>
    /// Provides methods to configure and register dependencies for the application.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers application-specific services in the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to which services will be added.</param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IConvertService, ConvertService>();
        }
    }
}
