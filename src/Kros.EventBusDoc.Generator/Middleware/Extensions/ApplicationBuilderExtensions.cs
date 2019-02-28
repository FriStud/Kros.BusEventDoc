using Microsoft.AspNetCore.Builder;
using System;

namespace Kros.EventBusDoc.Generator.Middleware.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEventBusDoc(
            this IApplicationBuilder builder,
            Action<EventBusDocOptions> setUpAction = null)
        {
            if (setUpAction == null)
            {
                builder.UseMiddleware<EventBusDocGeneratorMiddleware>();
            }
            else
            {
                var options = new EventBusDocOptions();
                setUpAction.Invoke(options);
                builder.UseMiddleware<EventBusDocGeneratorMiddleware>(options);
            }

            return builder;
        }
    }
}