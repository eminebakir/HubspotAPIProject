using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubspotDemoProject.Models
{
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
}
