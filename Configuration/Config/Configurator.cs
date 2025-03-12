using Microsoft.Extensions.Configuration;

namespace Configuration.Config
{
    /// <summary>
    /// Handles application configuration retrieval by loading settings from JSON files
    /// </summary>
    public class Configurator
    {
        public Configurator()
        {
        }

        public IConfiguration GetConfig()
        {
            var y = Directory.GetCurrentDirectory();
            return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.Local.json", false)
                    .Build();
        }
    }
}