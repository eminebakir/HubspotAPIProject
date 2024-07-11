using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubspotDemoProject.Services
{
    public class DealServices : GenericService<Deal>
    {
        public DealServices(IConfiguration configuration, ILogger<DealServices> logger)
            : base(configuration, logger, "deals")
        {
        }
    }
}
