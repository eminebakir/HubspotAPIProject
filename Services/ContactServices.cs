

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HubspotDemoProject.Services
{
    public class ContactServices : GenericService<Contact>
    {
        public ContactServices(IConfiguration configuration, ILogger<ContactServices> logger)
            : base(configuration, logger, "contacts")
        {
        }
    }
}
