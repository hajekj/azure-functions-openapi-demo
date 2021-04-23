using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureFunctionsOpenAPIDemo
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults(workerApplication =>
                {
                })
                .ConfigureAppConfiguration(configuration =>
                {
                })
                .ConfigureServices(services =>
                {
                })
                .Build();

            host.Run();
        }
    }
}