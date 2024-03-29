using System;
using Messages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace ClientUI
{   
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "ClientUI";
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                        .UseNServiceBus(context =>
                        {
                            var endpointConfiguration = new EndpointConfiguration("ClientUI");
                            endpointConfiguration.UseSerialization<SystemJsonSerializer>();
                            var transport = endpointConfiguration.UseTransport<LearningTransport>();

                            var routing = transport.Routing();
                            routing.RouteToEndpoint(typeof(PurchaseCart), "Sales");

                            endpointConfiguration.SendFailedMessagesTo("error");
                            endpointConfiguration.AuditProcessedMessagesTo("audit");
                            endpointConfiguration.SendHeartbeatTo("Particular.ServiceControl");

                            var metrics = endpointConfiguration.EnableMetrics();
                            metrics.SendMetricDataToServiceControl("Particular.Monitoring", TimeSpan.FromMilliseconds(500));

                            return endpointConfiguration;

                        })
                       .ConfigureWebHostDefaults(webBuilder =>
                        {
                            webBuilder.UseStartup<Startup>();
                        });
        }
    }
}
