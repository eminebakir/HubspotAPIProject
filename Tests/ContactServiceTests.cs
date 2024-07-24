using HubspotDemoProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using HubspotDemoProject.Models;
using Microsoft.Extensions.Logging;

namespace HubspotDemoProject.Test
{
    public class ContactServiceTests
    {
        private static readonly ILogger<ContactServiceTests> _logger;

        static ContactServiceTests()
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            _logger = serviceProvider.GetRequiredService<ILogger<ContactServiceTests>>();
        }

        public static async Task TestGetAllContacts()
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var contactService = serviceProvider.GetRequiredService<ContactService>();

            _logger.LogInformation("Testing ContactService - GetAll...");
            var apiResponse = await contactService.GetAllEntitiesAsync();

            foreach (var entity in apiResponse.Results)
            {
                var entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
                var contact = JsonConvert.DeserializeObject<Contact>(entityJson);
                _logger.LogInformation($"Contact ID: {entity.Id} - Contact Name: {contact.Properties.FirstName} {contact.Properties.LastName}");
            }
        }

        public static async Task TestGetContactById(long contactId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var contactService = serviceProvider.GetRequiredService<ContactService>();

            _logger.LogInformation("Testing ContactService - GetById...");
            var contactDetail = await contactService.GetEntityByIdAsync(contactId);

            var contact = JsonConvert.DeserializeObject<Contact>(contactDetail);

            _logger.LogInformation($"Contact Name: {contact.Properties.FirstName} {contact.Properties.LastName}");
        }

        public static async Task TestCreateContact(Contact newContact)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var contactService = serviceProvider.GetRequiredService<ContactService>();

            _logger.LogInformation("Testing ContactService - Create...");

            var createdContact = await contactService.CreateEntityAsync(newContact);
            _logger.LogInformation($"Created Contact ID: {createdContact.Id}");
            _logger.LogInformation($"Created Contact Name: {createdContact.Properties.FirstName} {createdContact.Properties.LastName}");
        }

        public static async Task TestDeleteContact(long contactId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var contactService = serviceProvider.GetRequiredService<ContactService>();

            _logger.LogInformation("Testing ContactService - Delete...");
            var result = await contactService.DeleteEntityAsync(contactId);

            if (result)
            {
                _logger.LogInformation($"Successfully deleted contact with ID: {contactId}");
            }
            else
            {
                _logger.LogError($"Failed to delete contact with ID: {contactId}");
            }
        }

        public static async Task TestUpdateContact(long contactId, Contact updatedContact)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var contactService = serviceProvider.GetRequiredService<ContactService>();

            _logger.LogInformation("Testing ContactService - Update...");
            var updatedEntity = await contactService.UpdateEntityAsync(contactId, updatedContact);

            _logger.LogInformation($"Successfully updated contact with ID: {contactId}");
            _logger.LogInformation($"Updated Contact Name: {updatedEntity.Properties.FirstName} {updatedEntity.Properties.LastName}");
        }
    }
}
