using HubspotDemoProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using HubspotDemoProject.Models;

namespace HubspotDemoProject.Test
{
    public static class CompanyServiceTests
    {
        public static async Task TestGetAllCompanies()
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var companyService = serviceProvider.GetRequiredService<CompanyService>();

            Console.WriteLine("Testing CompanyService - GetAll...");
            var apiResponse = await companyService.GetAllEntitiesAsync();

            foreach (var entity in apiResponse.Results)
            {
                var entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
                var company = JsonConvert.DeserializeObject<Company>(entityJson);
                Console.Write($"Company ID: {entity.Id} - ");
                Console.WriteLine($"Company Name: {company.Properties.Name}");
            }
        }

        public static async Task TestGetCompanyById(long companyId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var companyService = serviceProvider.GetRequiredService<CompanyService>();

            Console.WriteLine("Testing CompanyService - GetById...");
            var companyDetail = await companyService.GetEntityByIdAsync(companyId);

            var company = JsonConvert.DeserializeObject<Company>(companyDetail);

            Console.WriteLine($"Company Name: {company.Properties.Name}");
        }
        public static async Task TestCreateCompany(Company newCompany)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var companyService = serviceProvider.GetRequiredService<CompanyService>();

            Console.WriteLine("Testing CompanyService - Create...");

            var createdCompany = await companyService.CreateEntityAsync(newCompany);
            Console.WriteLine($"Created Company ID: {createdCompany.Id}");
            Console.WriteLine($"Created Company Name: {createdCompany.Properties.Name}");
        }

        public static async Task TestDeleteCompany(long companyId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var companyService = serviceProvider.GetRequiredService<CompanyService>();

            Console.WriteLine("Testing CompanyService - Delete...");
            var result = await companyService.DeleteEntityAsync(companyId);

            if (result)
            {
                Console.WriteLine($"Successfully deleted company with ID: {companyId}");
            }
            else
            {
                Console.WriteLine($"Failed to delete company with ID: {companyId}");
            }
        }

        public static async Task TestUpdateCompany(long companyId, Company updatedCompany)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var companyService = serviceProvider.GetRequiredService<CompanyService>();

            Console.WriteLine("Testing CompanyService - Update...");
            var updatedEntity = await companyService.UpdateEntityAsync(companyId, updatedCompany);

            Console.WriteLine($"Successfully updated company with ID: {companyId}");
            Console.WriteLine($"Updated Company Name: {updatedEntity.Properties.Name}");
        }

    }
}
