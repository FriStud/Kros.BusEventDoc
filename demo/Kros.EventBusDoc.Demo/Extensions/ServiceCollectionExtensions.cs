using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds MVC services to the specified <see cref="IServiceCollection" /> for Web API.
        /// This is a slimmed down version of <see cref="MvcServiceCollectionExtensions.AddMvc(IServiceCollection)"/>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
        public static IMvcCoreBuilder AddWebApi(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var builder = services.AddMvcCore();
            builder.AddAuthorization();
            builder.AddFormatterMappings();
            builder.AddJsonFormatters();
            builder.AddCors(o => o.AddPolicy("MyPolicy", b =>
            {
                b.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            return new MvcCoreBuilder(builder.Services, builder.PartManager);
        }
    }
}
