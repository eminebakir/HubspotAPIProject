using HubspotDemoProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using HubspotDemoProject.Models;
using Microsoft.Extensions.Logging;

namespace HubspotDemoProject.Test
{
    public class CompanyServiceTests
    {
        private static readonly ILogger<CompanyServiceTests> _logger;

        static CompanyServiceTests()
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            _logger = serviceProvider.GetRequiredService<ILogger<CompanyServiceTests>>();
        }

        public static async Task TestGetAllCompanies()
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var companyService = serviceProvider.GetRequiredService<CompanyService>();

            _logger.LogInformation("Testing CompanyService - GetAll...");
            var apiResponse = await companyService.GetAllEntitiesAsync();

            foreach (var entity in apiResponse.Results)
            {
                var entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
                var company = JsonConvert.DeserializeObject<Company>(entityJson);
                _logger.LogInformation($"Company ID: {entity.Id} - Company Name: {company.Properties.Name}");
            }
        }

        public static async Task TestGetCompanyById(long companyId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var companyService = serviceProvider.GetRequiredService<CompanyService>();

            _logger.LogInformation("Testing CompanyService - GetById...");
            var companyDetail = await companyService.GetEntityByIdAsync(companyId);

            var company = JsonConvert.DeserializeObject<Company>(companyDetail);

            _logger.LogInformation($"Company Name: {company.Properties.Name}");
        }

        public static async Task TestCreateCompany(Company newCompany)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var companyService = serviceProvider.GetRequiredService<CompanyService>();

            _logger.LogInformation("Testing CompanyService - Create...");

            var createdCompany = await companyService.CreateEntityAsync(newCompany);
            _logger.LogInformation($"Created Company ID: {createdCompany.Id}");
            _logger.LogInformation($"Created Company Name: {createdCompany.Properties.Name}");
        }

        public static async Task TestDeleteCompany(long companyId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var companyService = serviceProvider.GetRequiredService<CompanyService>();

            _logger.LogInformation("Testing CompanyService - Delete...");
            var result = await companyService.DeleteEntityAsync(companyId);

            if (result)
            {
                _logger.LogInformation($"Successfully deleted company with ID: {companyId}");
            }
            else
            {
                _logger.LogError($"Failed to delete company with ID: {companyId}");
            }
        }

        public static async Task TestUpdateCompany(long companyId, Company updatedCompany)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var companyService = serviceProvider.GetRequiredService<CompanyService>();

            _logger.LogInformation("Testing CompanyService - Update...");
            var updatedEntity = await companyService.UpdateEntityAsync(companyId, updatedCompany);

            _logger.LogInformation($"Successfully updated company with ID: {companyId}");
            _logger.LogInformation($"Updated Company Name: {updatedEntity.Properties.Name}");
        }
    }
}
