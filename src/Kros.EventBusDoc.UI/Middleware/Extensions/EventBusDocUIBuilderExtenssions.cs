using Kros.EventBusDoc.UI.Middleware.Options;
using Microsoft.AspNetCore.Builder;
using System;

namespace Kros.EventBusDoc.UI.Middleware.Extensions
{
    public static class EventBusDocUIBuilderExtenssions
    {
        public static IApplicationBuilder UseEventBusDocUI(
            this IApplicationBuilder app,
            Action<EventBusDocUIOptions> setupAction = null)
        {
            if (setupAction == null)
            {
                // Don't pass options so it can be configured/injected via DI container instead
                app.UseMiddleware<EventBusDocUIMiddleware>();
            }
            else
            {
                // Configure an options instance here and pass directly to the middleware
                var options = new EventBusDocUIOptions();
                setupAction.Invoke(options);

                app.UseMiddleware<EventBusDocUIMiddleware>(options);
            }

            return app;
        }
    }
}