using Kros.EventBusDoc.Demo2.Extensions;
using Kros.EventBusDoc.Generator.BusentScour.Generators;
using Kros.EventBusDoc.Generator.Middleware;
using Kros.EventBusDoc.Generator.Middleware.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kros.EventBusDoc.Demo2
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

            services.AddEventBusDocGen(c => c.EventBusDoc("v2", new Info { Version = "v2", Title = "Demo2" }));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("MyPolicy");
            app.UseMvc();
            app.UseEventBusDoc(ebd =>
           {
               ebd.ServiceSettings = new ServiceSettings
               {
                   Name = "Demo 2",
                   Version = "demo v 1.2",
                   Description = "Demo 2 for demo puposes"
               };
           });
        }
    }
}
