using System;
using System.IO;
using System.Threading.Tasks;
using GenericHostSample;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace sampleconsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration((config) =>
                {
                    config.AddEnvironmentVariables();
                })
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.SetBasePath(Environment.CurrentDirectory);
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    config.AddEnvironmentVariables(prefix: "ASPNETCORE_");
                    config.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<MyServiceA>();
                    services.AddHostedService<MyServiceB>();
                });

            await host.RunConsoleAsync();
        }

        // public static async Task Main(string[] args)
        // {
        //     var builder = new HostBuilder()
        //         .ConfigureServices((hostContext, services) =>
        //         {
        //             services.AddHostedService<MyServiceA>();
        //         });

        //     await builder.RunConsoleAsync();
        // }
    }
}
