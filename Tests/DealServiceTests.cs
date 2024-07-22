using HubspotDemoProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using HubspotDemoProject.Models;

namespace HubspotDemoProject.Test
{
    public static class DealServiceTests
    {
        public static async Task TestGetAllDeals()
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var dealService = serviceProvider.GetRequiredService<DealService>();

            Console.WriteLine("Testing DealService - GetAll...");
            var apiResponse = await dealService.GetAllEntitiesAsync();

            foreach (var entity in apiResponse.Results)
            {
                var entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
                var deal = JsonConvert.DeserializeObject<Deal>(entityJson);
                Console.Write($"Deal ID: {entity.Id} - ");
                Console.WriteLine($"Deal Name: {deal.Properties.DealName}");
            }

        }

        public static async Task TestGetDealById(long dealId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var dealService = serviceProvider.GetRequiredService<DealService>();

            Console.WriteLine("Testing DealService - GetById...");
            var dealDetail = await dealService.GetEntityByIdAsync(dealId);

            var deal = JsonConvert.DeserializeObject<Deal>(dealDetail);

            Console.WriteLine($"Deal Name: {deal.Properties.DealName}");
        }

        public static async Task TestCreateDeal(Deal newDeal)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var dealService = serviceProvider.GetRequiredService<DealService>();

            Console.WriteLine("Testing DealService - Create...");
            

            var createdDeal = await dealService.CreateEntityAsync(newDeal);
            Console.WriteLine($"Created Deal ID: {createdDeal.Id}");
            Console.WriteLine($"Created Deal Name: {createdDeal.Properties.DealName}");
        }

        public static async Task TestDeleteDeal(long dealId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var dealService = serviceProvider.GetRequiredService<DealService>();

            Console.WriteLine("Testing DealService - Delete...");
            var result = await dealService.DeleteEntityAsync(dealId);

            if (result)
            {
                Console.WriteLine($"Successfully deleted deal with ID: {dealId}");
            }
            else
            {
                Console.WriteLine($"Failed to delete deal with ID: {dealId}");
            }
        }

        public static async Task TestUpdateDeal(long dealId, Deal updatedDeal)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var dealService = serviceProvider.GetRequiredService<DealService>();

            Console.WriteLine("Testing DealService - Update...");
            var updatedEntity = await dealService.UpdateEntityAsync(dealId, updatedDeal);

            Console.WriteLine($"Successfully updated deal with ID: {dealId}");
            Console.WriteLine($"Updated Deal Name: {updatedEntity.Properties.DealName}");
        }

    }
}
