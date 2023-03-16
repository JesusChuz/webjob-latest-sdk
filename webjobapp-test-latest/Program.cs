using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace webjobapp_test_latest
{
    class Program
    {
        static async Task Main()
        {
            var builder = new HostBuilder();
            builder.UseEnvironment(EnvironmentName.Development);
            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            });
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorageQueues();
                b.AddAzureStorageBlobs();
            });
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}