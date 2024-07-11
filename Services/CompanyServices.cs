using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubspotDemoProject.Services
{
    public class CompanyServices : GenericService<Company>
    {
        public CompanyServices(IConfiguration configuration, ILogger<CompanyServices> logger)
    : base(configuration, logger, "companies")
        {
        }
    }
}
