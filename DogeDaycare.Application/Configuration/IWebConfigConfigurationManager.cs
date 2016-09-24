using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Configuration
{
    public interface IWebConfigConfigurationManager
    {
        string GetAppSetting(string key);
    }
}
