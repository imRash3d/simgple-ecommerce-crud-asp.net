using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEcommerce.Infrastructure.Contracts
{
  public  interface IConfigurationService
    {
        string GetAppsettingValueByKey(string configKeyValue);
    }
}
