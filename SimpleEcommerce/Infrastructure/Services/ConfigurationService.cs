using Microsoft.Extensions.Configuration;
using SimpleEcommerce.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEcommerce.Infrastructure.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public IConfiguration Configuration { get; }

        public ConfigurationService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public string GetAppsettingValueByKey(string configKeyValue)
        {
            var value = Configuration.GetSection($"appSettings:{configKeyValue}").Value;
            return value;
        }
    }
}
