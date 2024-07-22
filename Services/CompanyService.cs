using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using HubspotDemoProject.Models;

namespace HubspotDemoProject.Services
{
    public class CompanyService : GenericService<Company>
    {
        public CompanyService(IConfiguration configuration, ILogger<CompanyService> logger)
    : base(configuration, logger, "companies")
        {
        }
    }
}
