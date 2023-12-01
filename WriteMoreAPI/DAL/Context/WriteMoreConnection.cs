using System.Net.NetworkInformation;

namespace WriteMoreAPI.DAL.Context
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
