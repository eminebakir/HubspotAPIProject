using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubspotDemoProject.Models
{
    public class ApiResponse<T> where T : EntityBase
    {
        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
