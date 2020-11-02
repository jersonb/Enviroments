using System.Net.Http;
using Enviroments.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace Enviroments.Test
{
    public static class TestServerContext
    {
        public static IConfiguration Configuration {get; set;}
        public static TestServer ServerContext(string enviroment = null)
        {
            var host = new WebHostBuilder();

            if (!string.IsNullOrEmpty(enviroment))
            {
                host.UseEnvironment(enviroment);
            }

             host.ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.Sources.Clear();

                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    config.AddEnvironmentVariables();
                    Configuration = config.Build();
                });

            host.UseStartup<Startup>();

            return new TestServer(host);
        }

        public static HttpClient Client(string enviroment = null)
            => ServerContext(enviroment).CreateClient(); 
    }
}