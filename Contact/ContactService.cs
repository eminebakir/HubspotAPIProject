//using System;
//using System.Net;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using RestSharp;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Configuration;

//namespace HubspotDemoProject.Contact
//{
//    public class ContactService
//    {
//        private readonly RestClient _client;
//        private readonly string _authToken;
//        private readonly ILogger<ContactService> _logger;

//        public ContactService(IConfiguration configuration, ILogger<ContactService> logger)
//        {
//            _authToken = configuration["HubSpot:AuthToken"];
//            _client = new RestClient("https://api.hubapi.com");
//            _logger = logger;
//        }

//        public async Task GetAllContactsAsync(int limit = 10, bool archived = false)
//        {
//            var request = new RestRequest("crm/v3/objects/contacts", Method.GET);
//            request.AddQueryParameter("limit", limit.ToString());
//            request.AddQueryParameter("archived", archived.ToString().ToLower());
//            request.AddHeader("Accept", "application/json");
//            request.AddHeader("Authorization", $"Bearer {_authToken}");

//            try
//            {
//                _logger.LogInformation("Sending request to get all contacts.");
//                var response = await _client.ExecuteAsync(request);

//                if (response.StatusCode == HttpStatusCode.OK)
//                {
//                    _logger.LogInformation("Successfully retrieved contacts.");
//                    var contactsResponse = JsonConvert.DeserializeObject<ContactsResponse>(response.Content);
//                    foreach (var contact in contactsResponse.Results)
//                    {
//                        Console.WriteLine($"Contact Name: {contact.Properties.FirstName} {contact.Properties.LastName}");
//                    }
//                }
//                else
//                {
//                    _logger.LogError($"Error retrieving contacts: {response.StatusCode} - {response.Content}");
//                    throw new ApplicationException($"Error retrieving contacts: {response.StatusCode}");
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Exception occurred while getting contacts.");
//                throw;
//            }
//        }

//        public async Task<string> GetContactByIdAsync(long contactId, bool archived = false)
//        {
//            var request = new RestRequest($"crm/v3/objects/contacts/{contactId}", Method.GET);
//            request.AddQueryParameter("archived", archived.ToString().ToLower());
//            request.AddHeader("Accept", "application/json");
//            request.AddHeader("Authorization", $"Bearer {_authToken}");

//            try
//            {
//                _logger.LogInformation($"Sending request to get contact by ID: {contactId}");
//                var response = await _client.ExecuteAsync(request);

//                if (response.StatusCode == HttpStatusCode.OK)
//                {
//                    _logger.LogInformation($"Successfully retrieved contact with ID: {contactId}");
//                    return response.Content;
//                }
//                else
//                {
//                    _logger.LogError($"Error retrieving contact with ID {contactId}: {response.StatusCode} - {response.Content}");
//                    throw new ApplicationException($"Error retrieving contact with ID {contactId}: {response.StatusCode}");
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, $"Exception occurred while getting contact with ID {contactId}");
//                throw;
//            }
//        }
//    }
//}
