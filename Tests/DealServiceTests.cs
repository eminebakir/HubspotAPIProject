using HubspotDemoProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using HubspotDemoProject.Models;
using Microsoft.Extensions.Logging;

namespace HubspotDemoProject.Test
{
    public class DealServiceTests
    {
        private static readonly ILogger<DealServiceTests> _logger;

        static DealServiceTests()
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            _logger = serviceProvider.GetRequiredService<ILogger<DealServiceTests>>();
        }

        public static async Task TestGetAllDeals()
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var dealService = serviceProvider.GetRequiredService<DealService>();

            _logger.LogInformation("Testing DealService - GetAll...");
            var apiResponse = await dealService.GetAllEntitiesAsync();

            foreach (var entity in apiResponse.Results)
            {
                var entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
                var deal = JsonConvert.DeserializeObject<Deal>(entityJson);
                _logger.LogInformation($"Deal ID: {entity.Id} - Deal Name: {deal.Properties.DealName}");
            }
        }

        public static async Task TestGetDealById(long dealId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var dealService = serviceProvider.GetRequiredService<DealService>();

            _logger.LogInformation("Testing DealService - GetById...");
            var dealDetail = await dealService.GetEntityByIdAsync(dealId);

            var deal = JsonConvert.DeserializeObject<Deal>(dealDetail);

            _logger.LogInformation($"Deal Name: {deal.Properties.DealName}");
        }

        public static async Task TestCreateDeal(Deal newDeal)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var dealService = serviceProvider.GetRequiredService<DealService>();

            _logger.LogInformation("Testing DealService - Create...");
            var createdDeal = await dealService.CreateEntityAsync(newDeal);
            _logger.LogInformation($"Created Deal ID: {createdDeal.Id}");
            _logger.LogInformation($"Created Deal Name: {createdDeal.Properties.DealName}");
        }

        public static async Task TestDeleteDeal(long dealId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var dealService = serviceProvider.GetRequiredService<DealService>();

            _logger.LogInformation("Testing DealService - Delete...");
            var result = await dealService.DeleteEntityAsync(dealId);

            if (result)
            {
                _logger.LogInformation($"Successfully deleted deal with ID: {dealId}");
            }
            else
            {
                _logger.LogError($"Failed to delete deal with ID: {dealId}");
            }
        }

        public static async Task TestUpdateDeal(long dealId, Deal updatedDeal)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var dealService = serviceProvider.GetRequiredService<DealService>();

            _logger.LogInformation("Testing DealService - Update...");
            var updatedEntity = await dealService.UpdateEntityAsync(dealId, updatedDeal);

            _logger.LogInformation($"Successfully updated deal with ID: {dealId}");
            _logger.LogInformation($"Updated Deal Name: {updatedEntity.Properties.DealName}");
        }
    }
}
