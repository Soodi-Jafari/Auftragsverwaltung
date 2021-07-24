using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auftragsverwaltung.Web.Settings
{
    public static class ConfigurationInterfaceExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration config)
        {
            return config.GetConnectionString("DefaultConnection");
        }
    }
}
