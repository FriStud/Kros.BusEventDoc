using Kros.EventBusDoc.Demo.Types;
using Kros.EventBusDoc.Generator.BusentAnnotation;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

[assembly: BusEvent(EventType =typeof(ISendEvent) )]
[assembly: EventBusCommandConsumer(EventType =typeof(IConsumeOne) )]
[assembly: EventBusCommandSender(EventType =typeof(ISendCommand) )]

namespace Kros.EventBusDoc.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}