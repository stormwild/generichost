using System;

namespace sampleconsole
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .Build();

            await host.RunAsync();
        }
    }
}
