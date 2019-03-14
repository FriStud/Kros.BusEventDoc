using Kros.EventBusDoc.Generator.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kros.EventBusDoc.Demo.Extensions;
using Kros.EventBusDoc.Demo.Contracts;
using Kros.EventBusDoc.Generator.BusentScour.Generators;
using Kros.EventBusDoc.UI.Middleware;

namespace Kros.EventBusDoc.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApi();

            services.AddHttpClient<IOrderingService, OrderingService>();

            services.AddEventBusDocGen(c => c.EventBusDoc("v1", new Info { Version = "v1", Title = "Demo" }));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();

            app.UseCors("MyPolicy");
            app.UseEventBusDoc(ebd =>
            {
                ebd.ServiceSettings = new ServiceSettings
                {
                    Name = "Main Demo 1",
                    Version = "demo v 1.2",
                    Description = "Main Demo 1 for demo puposes"
                };
            });

            app.UseEventBusDocUI(c =>
            {
                c.EventBusDocEndPoint("http://localhost:5001/busent/v1/busent.json", "Demo v1");
                c.EventBusDocEndPoint("http://localhost:5000/busent/v2/busent.json", "Demo v2");
            });
        }
    }
}