using Microsoft.Extensions.Configuration;
using System.IO;

namespace PhotoSharingAppJessieDomingo
{
    public static class GetConfiguration
    {
        private static IConfiguration configuration;

        static GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appSettings.Development.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        public static string GetConnectionString(string name)
        {
            return configuration.GetConnectionString(name);
        }

    }
}
