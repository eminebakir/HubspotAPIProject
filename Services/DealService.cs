using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using HubspotDemoProject.Models;

namespace HubspotDemoProject.Services
{
    public class DealService : GenericService<Deal>
    {
        public DealService(IConfiguration configuration, ILogger<DealService> logger)
            : base(configuration, logger, "deals")
        {
        }
    }
}
