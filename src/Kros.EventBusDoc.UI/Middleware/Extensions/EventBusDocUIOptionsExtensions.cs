using Kros.EventBusDoc.UI.Middleware.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kros.EventBusDoc.UI.Middleware.Extensions
{
    public static class EventBusDocUIOptionsExtensions
    {
        /// <summary>
        /// Injects additional CSS stylesheets into the index.html page
        /// </summary>
        /// <param name="options"></param>
        /// <param name="path">A path to the stylesheet - i.e. the link "href" attribute</param>
        /// <param name="media">The target media - i.e. the link "media" attribute</param>
        public static void InjectStylesheet(this EventBusDocUIOptions options, string path, string media = "screen")
        {
            var builder = new StringBuilder(options.HeadContent);
            builder.AppendLine($"<link href='{path}' rel='stylesheet' media='{media}' type='text/css' />");
            options.HeadContent = builder.ToString();
        }

        /// <summary>
        /// Injects additional Javascript files into the index.html page
        /// </summary>
        /// <param name="options"></param>
        /// <param name="path">A path to the javascript - i.e. the script "src" attribute</param>
        /// <param name="type">The script type - i.e. the script "type" attribute</param>
        public static void InjectJavascript(this EventBusDocUIOptions options, string path, string type = "text/javascript")
        {
            var builder = new StringBuilder(options.HeadContent);
            builder.AppendLine($"<script src='{path}' type='{type}'></script>");
            options.HeadContent = builder.ToString();
        }

        /// <summary>
        /// Adds Swagger JSON endpoints. Can be fully-qualified or relative to the UI page
        /// </summary>
        /// <param name="options"></param>
        /// <param name="url">Can be fully qualified or relative to the current host</param>
        /// <param name="name">The description that appears in the document selector drop-down</param>
        public static void EventBusDocEndPoint(this EventBusDocUIOptions options, string url, string name)
        {
            var urls = new List<UrlDescriptor>(options.ConfigObject.Urls ?? Enumerable.Empty<UrlDescriptor>());
            urls.Add(new UrlDescriptor { Url = url, Name = name });
            options.ConfigObject.Urls = urls;
        }
    }
}