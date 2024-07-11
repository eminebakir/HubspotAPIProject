//using Newtonsoft.Json;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HubspotDemoProject.Contact
//{
//    public class Contact
//    {
//        [JsonProperty("id")]
//        public string Id { get; set; }

//        [JsonProperty("properties")]
//        public ContactProperties Properties { get; set; }
//    }

//    public class ContactProperties
//    {
//        [JsonProperty("firstname")]
//        public string FirstName { get; set; }

//        [JsonProperty("lastname")]
//        public string LastName { get; set; }
//    }

//    public class ContactsResponse
//    {
//        [JsonProperty("results")]
//        public List<Contact> Results { get; set; }
//    }

//}