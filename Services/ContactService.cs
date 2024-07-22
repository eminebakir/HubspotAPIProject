using HubspotDemoProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HubspotDemoProject.Services
{
    public class ContactService : GenericService<Contact>
    {
        public ContactService(IConfiguration configuration, ILogger<ContactService> logger)
            : base(configuration, logger, "contacts")
        {
        }
    }
}
