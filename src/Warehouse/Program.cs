using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using Warehouse.Context;

namespace Warehouse
{    
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Billing";
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Warehouse");

                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();
                    endpointConfiguration.UseTransport<LearningTransport>();

                    endpointConfiguration.SendFailedMessagesTo("error");
                    endpointConfiguration.AuditProcessedMessagesTo("audit");
                    endpointConfiguration.SendHeartbeatTo("Particular.ServiceControl");

                    var metrics = endpointConfiguration.EnableMetrics();
                    metrics.SendMetricDataToServiceControl("Particular.Monitoring", TimeSpan.FromMilliseconds(500));

                    return endpointConfiguration;
                })
                .ConfigureAppConfiguration(cfg =>
                {
                    cfg.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<IWarehouseDbContext, WarehouseDbContext>();
                    services.AddScoped<IPickListRepository, PickListRepository>();
                });
            
            return hostBuilder;
        }
    }
}
