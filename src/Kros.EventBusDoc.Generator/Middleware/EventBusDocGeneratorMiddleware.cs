using Kros.EventBusDoc.Generator.BusentScour.Generators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Generator.Middleware
{
    public class EventBusDocGeneratorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TemplateMatcher _requesMatcher;
        private readonly ServiceSettings _settings;

        public EventBusDocGeneratorMiddleware(RequestDelegate next, EventBusDocOptions options)
        {
            _next = next;
            _settings = options.ServiceSettings;
            _requesMatcher = new TemplateMatcher(TemplateParser.Parse(options.RouteTemplate), new RouteValueDictionary());
        }

        public async Task Invoke(HttpContext context, IBusentProvider provider)
        {
            if (!RequestingBusentDocument(context.Request, out string documentName))
            {
                await _next.Invoke(context);
                return;
            }

            await RespondWithBusentJson(context.Response, provider);
        }

        private bool RequestingBusentDocument(HttpRequest request, out string documentName)
        {
            documentName = null;

            if (!HttpMethods.IsGet(request.Method)) return false;

            var routeValues = new RouteValueDictionary();
            if (!_requesMatcher.TryMatch(request.Path, routeValues) || !routeValues.ContainsKey("documentName")) return false;

            documentName = routeValues["documentName"].ToString();

            return true;
        }

        private void RespondWithNotFound(HttpResponse response)
        {
            response.StatusCode = 404;
        }

        private async Task RespondWithBusentJson(HttpResponse response, IBusentProvider provider)
        {
            response.StatusCode = 200;
            response.ContentType = "application/json;charset=utf-8";

            await response.WriteAsync(provider.Serialize(_settings), new UTF8Encoding(false));
        }
    }
}