using App.Configurations;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(App.Startup))]

namespace App
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Access the configuration settings
            var configuration = builder.GetContext().Configuration;

            // Register services with DI container
            builder.Services.AddServices();
        }
    }
}
