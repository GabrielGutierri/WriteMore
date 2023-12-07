using Microsoft.Extensions.Configuration;
using System.Net.NetworkInformation;

namespace WriteMore.Data.Context
{
    public class WriteMoreConnection
    {
        public static IConfiguration ConnectionConfig
        {
            get
            {
                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                return Configuration;
            }
        } 
    }
}
