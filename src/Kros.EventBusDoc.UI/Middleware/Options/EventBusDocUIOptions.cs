using Kros.EventBusDoc.UI.Extensions;
using System;
using System.IO;

namespace Kros.EventBusDoc.UI.Middleware.Options
{
    /// <summary>
    /// Let's user define the basic options interacting with UI
    /// and routing among endpoints via ConfigObject
    /// </summary>
    public class EventBusDocUIOptions
    {
        public Func<Stream> IndexStream { get; set; } = () => "index.html".GetEmbeddedFileStream();

        /// <summary>
        /// Gets or sets a route prefix for accessing the eventbusdoc-ui
        /// </summary>
        public string RoutePrefix { get; internal set; } = "busent";

        /// <summary>
        /// Gets or sets a title for the ui page
        /// </summary>
        public string DocumentTitle { get; internal set; }

        /// <summary>
        /// Gets or sets additional content to place in the head of the swagger-ui page
        /// </summary>
        public string HeadContent { get; internal set; }

        /// <summary>
        /// Gets the JavaScript config object, represented as JSON, that will be passed to the UI
        /// </summary>
        public ConfigObject ConfigObject { get; } = new ConfigObject();

    }
}