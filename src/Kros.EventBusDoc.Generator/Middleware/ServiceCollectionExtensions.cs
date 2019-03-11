using Kros.EventBusDoc.Generator.BusentScour.Generators;
using Kros.EventBusDoc.Generator.BusentScour.Scourers;
using Kros.EventBusDoc.Generator.BusentScour.XmlReader;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kros.EventBusDoc.Generator.Middleware
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBusDocGen(
           this IServiceCollection services,
           Action<EventBusDocGenOptions> setupAction = null)
        {

            services.AddTransient<IAttributeFetcher, AttributeFetcher>();
            services.AddTransient<IXmlDocumentationReader, XmlDocumentationReader>();
            services.AddTransient<IScourer, DeclarativeScourer>();
            services.AddTransient<IBusentProvider, DeclarativeGenerator>();

            if (setupAction != null)
                services.ConfigureEventBusDocGen(setupAction);

            return services;
        }

        public static void ConfigureEventBusDocGen(
            this IServiceCollection services,
            Action<EventBusDocGenOptions> setupAction)
        {
            services.Configure(setupAction);
        }
    }
}