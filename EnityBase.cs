using HubspotDemoProject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubspotDemoProject
{
    public abstract class EntityBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
    public class Company : EntityBase
    {
        [JsonProperty("properties")]
        public CompanyProperties Properties { get; set; }
    }

    public class CompanyProperties
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }
    }

    public class Contact : EntityBase
    {
        [JsonProperty("properties")]
        public ContactProperties Properties { get; set; }
    }

    public class ContactProperties
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }
    }

    public class Deal : EntityBase
    {
        [JsonProperty("properties")]
        public DealProperties Properties { get; set; }
    }

    public class DealProperties
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("dealname")]
        public string DealName { get; set; }
    }

}

public class ApiResponse<T> where T : EntityBase
{
    [JsonProperty("results")]
    public List<T> Results { get; set; }
}

