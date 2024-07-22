using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace HubspotDemoProject.Services
{
    public class ConfigureServices
    {
        public static ServiceProvider GetConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Configure services
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddLogging(configure => configure.AddConsole());

            serviceCollection.AddTransient(provider =>
               new ContactService(configuration, provider.GetService<ILogger<ContactService>>()));

            serviceCollection.AddTransient(provider =>
               new CompanyService(configuration, provider.GetService<ILogger<CompanyService>>()));

            serviceCollection.AddTransient(provider =>
               new DealService(configuration, provider.GetService<ILogger<DealService>>()));

            return serviceCollection.BuildServiceProvider();
        }
    }
}