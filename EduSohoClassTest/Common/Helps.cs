using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSohoClassTest.Common
{
    public static class Helps
    {
        public static string GetConfigurationValue(string key)
        {
            string values = ConfigurationManager.AppSettings[key];
            return values;
        }
    }
}
