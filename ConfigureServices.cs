using HubspotDemoProject.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace HubspotDemoProject
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
            
            serviceCollection.AddTransient<ContactServices>(provider =>
               new ContactServices(configuration, provider.GetService<ILogger<ContactServices>>()));

            serviceCollection.AddTransient<CompanyServices>(provider =>
               new CompanyServices(configuration, provider.GetService<ILogger<CompanyServices>>()));

            serviceCollection.AddTransient<DealServices>(provider =>
               new DealServices(configuration, provider.GetService<ILogger<DealServices>>()));

            return serviceCollection.BuildServiceProvider();
        }
    }
}