using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubspotDemoProject.Models
{
    public abstract class EntityBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
