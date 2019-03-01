using Kros.EventBusDoc.Generator.Middleware;
using Kros.EventBusDoc.Generator.Middleware.Extensions;
using Kros.EventBusDoc.UI.Middleware.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kros.EventBusDoc.Demo.Extensions;
using Kros.EventBusDoc.Demo.Services;

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
            app.UseEventBusDoc();
            app.UseEventBusDocUI(c => { c.EventBusDocEndPoint("v1/busent.json", "Demo v1"); });
        }
    }
}