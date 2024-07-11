using HubspotDemoProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace HubspotDemoProject.Test
{
    public static class ContactServiceTests
    {
        public static async Task TestGetAllContacts()
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var contactService = serviceProvider.GetRequiredService<ContactServices>();

            Console.WriteLine("Testing ContactService - GetAll...");
            var apiResponse = await contactService.GetAllEntitiesAsync();

            foreach (var entity in apiResponse.Results)
            {
                var entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
                var contact = JsonConvert.DeserializeObject<Contact>(entityJson);
                Console.Write($"Contact ID: {entity.Id} - ");
                Console.WriteLine($"Contact Name: {contact.Properties.FirstName} {contact.Properties.LastName}");
            }


        }
        public static async Task TestGetContactById(long contactId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var contactService = serviceProvider.GetRequiredService<ContactServices>();

            Console.WriteLine("Testing ContactService - GetById...");
            var contactDetail = await contactService.GetEntityByIdAsync(contactId);

            var contact = JsonConvert.DeserializeObject<Contact>(contactDetail);

            Console.WriteLine($"Contact Name: {contact.Properties.FirstName} {contact.Properties.LastName}");

        }

        public static async Task TestCreateContact(Contact newContact)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var contactService = serviceProvider.GetRequiredService<ContactServices>();

            Console.WriteLine("Testing ContactService - Create...");

            var createdContact = await contactService.CreateEntityAsync(newContact);
            Console.WriteLine($"Created Contact ID: {createdContact.Id}");
            Console.WriteLine($"Created Contact Name: {createdContact.Properties.FirstName} {createdContact.Properties.LastName}");
        }
        public static async Task TestDeleteContact(long contactId)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var contactService = serviceProvider.GetRequiredService<ContactServices>();

            Console.WriteLine("Testing ContactService - Delete...");
            var result = await contactService.DeleteEntityAsync(contactId);

            if (result)
            {
                Console.WriteLine($"Successfully deleted contact with ID: {contactId}");
            }
            else
            {
                Console.WriteLine($"Failed to delete contact with ID: {contactId}");
            }
        }
        public static async Task TestUpdateContact(long contactId, Contact updatedContact)
        {
            var serviceProvider = ConfigureServices.GetConfigureServices();
            var contactService = serviceProvider.GetRequiredService<ContactServices>();

            Console.WriteLine("Testing ContactService - Update...");
            var updatedEntity = await contactService.UpdateEntityAsync(contactId, updatedContact);

            Console.WriteLine($"Successfully updated contact with ID: {contactId}");
            Console.WriteLine($"Updated Contact Name: {updatedEntity.Properties.FirstName} {updatedEntity.Properties.LastName}");
        }
    }
}
