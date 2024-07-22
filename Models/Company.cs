using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubspotDemoProject.Models
{
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
}
