using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubspotDemoProject.Models
{
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
