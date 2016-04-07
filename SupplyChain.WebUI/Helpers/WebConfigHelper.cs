using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SupplyChain.WebUI.Helpers
{
    public static class WebConfigHelper
    {
        public static string GetConnectionString(string name)
        {
            var connectionString = string.Empty;
            connectionString = WebConfigurationManager.ConnectionStrings[name].ToString();
            return connectionString;
        }
    }
}
