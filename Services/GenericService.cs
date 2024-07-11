using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace HubspotDemoProject
{
    public class GenericService<T> where T : EntityBase
    {
        private readonly RestClient _client;
        private readonly string _authToken;
        private readonly ILogger<GenericService<T>> _logger;
        private readonly string _entityName;

        public GenericService(IConfiguration configuration, ILogger<GenericService<T>> logger, string entityName)
        {
            _authToken = configuration["HubSpot:AuthToken"];
            _client = new RestClient("https://api.hubapi.com");
            _logger = logger;
            _entityName = entityName;
        }

        public async Task<ApiResponse<T>> GetAllEntitiesAsync(int limit = 10, bool archived = false)
        {
            var request = new RestRequest($"crm/v3/objects/{_entityName}", Method.GET);
            request.AddQueryParameter("limit", limit.ToString());
            request.AddQueryParameter("archived", archived.ToString().ToLower());
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_authToken}");

            try
            {
                _logger.LogInformation($"Sending request to get all {_entityName} entities.");
                var response = await _client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    _logger.LogInformation($"Successfully retrieved {_entityName} entities.");
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content);
                    return apiResponse;
                }
                else
                {
                    _logger.LogError($"Error retrieving {_entityName} entities: {response.StatusCode} - {response.Content}");
                    throw new ApplicationException($"Error retrieving {_entityName} entities: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while getting {_entityName} entities.");
                throw;
            }
        }

        public async Task<string> GetEntityByIdAsync(long entityId, bool archived = false)
        {
            var request = new RestRequest($"crm/v3/objects/{_entityName}/{entityId}", Method.GET);
            request.AddQueryParameter("archived", archived.ToString().ToLower());
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_authToken}");

            try
            {
                _logger.LogInformation($"Sending request to get {_entityName} by ID: {entityId}");
                var response = await _client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    _logger.LogInformation($"Successfully retrieved {_entityName} with ID: {entityId}");
                    return response.Content;
                }
                else
                {
                    _logger.LogError($"Error retrieving {_entityName} with ID {entityId}: {response.StatusCode} - {response.Content}");
                    throw new ApplicationException($"Error retrieving {_entityName} with ID {entityId}: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while getting {_entityName} with ID {entityId}");
                throw;
            }
        }

        public async Task<T> CreateEntityAsync(T entity)
        {
            var request = new RestRequest($"crm/v3/objects/{_entityName}", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_authToken}");

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var jsonBody = JsonConvert.SerializeObject(entity, jsonSettings);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            try
            {
                _logger.LogInformation($"Sending request to create new {_entityName} entity.");
                var response = await _client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    _logger.LogInformation($"Successfully created {_entityName} entity.");
                    return JsonConvert.DeserializeObject<T>(response.Content);
                }
                else
                {
                    _logger.LogError($"Error creating {_entityName} entity: {response.StatusCode} - {response.Content}");
                    throw new ApplicationException($"Error creating {_entityName} entity: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while creating {_entityName} entity.");
                throw;
            }
        }


        public async Task<bool> DeleteEntityAsync(long entityId)
        {
            var request = new RestRequest($"crm/v3/objects/{_entityName}/{entityId}", Method.DELETE);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_authToken}");

            try
            {
                _logger.LogInformation($"Sending request to delete {_entityName} with ID: {entityId}");
                var response = await _client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    _logger.LogInformation($"Successfully deleted {_entityName} with ID: {entityId}");
                    return true;
                }
                else
                {
                    _logger.LogError($"Error deleting {_entityName} with ID {entityId}: {response.StatusCode} - {response.Content}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while deleting {_entityName} with ID {entityId}");
                throw;
            }
        }

        public async Task<T> UpdateEntityAsync(long entityId, T entity)
        {
            var request = new RestRequest($"crm/v3/objects/{_entityName}/{entityId}", Method.PATCH);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_authToken}");
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var jsonBody = JsonConvert.SerializeObject(entity, jsonSettings);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            try
            {
                _logger.LogInformation($"Sending request to update {_entityName} with ID: {entityId}");
                var response = await _client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    _logger.LogInformation($"Successfully updated {_entityName} with ID: {entityId}");
                    var updatedEntity = JsonConvert.DeserializeObject<T>(response.Content);
                    return updatedEntity;
                }
                else
                {
                    _logger.LogError($"Error updating {_entityName} with ID {entityId}: {response.StatusCode} - {response.Content}");
                    throw new ApplicationException($"Error updating {_entityName} with ID {entityId}: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while updating {_entityName} with ID {entityId}");
                throw;
            }
        }
    }
}