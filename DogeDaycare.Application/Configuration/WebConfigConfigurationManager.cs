using DogeDaycare.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DogeDaycare
{
    class WebConfigConfigurationManager : IWebConfigConfigurationManager
    {
        public string GetAppSetting(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }
    }
}
