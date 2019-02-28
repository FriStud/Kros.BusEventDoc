using Kros.EventBusDoc.UI.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kros.EventBusDoc.UI.Middleware.Options
{
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
        public ConfigObject ConfigObject { get; internal set; }

        public object OAuthConfigObject { get; internal set; }

        public EventBusDocUIOptions()
        {
            ConfigObject = new ConfigObject();
        }
    }

    public class UrlDescriptor
    {
        public string Url { get; set; }

        public string Name { get; set; }
    }

    public class ConfigObject
    {
        #region Properties

        public string Url { get; set; } = "";

        /// <summary>
        /// One or more Swagger JSON endpoints (url and name) to power the UI
        /// </summary>
        public List<UrlDescriptor> Urls { get; internal set; }

        /// <summary>
        /// If set to true, enables deep linking for tags and operations
        /// </summary>
        public bool DeepLinking { get; set; } = false;

        /// <summary>
        /// Controls the display of operationId in operations list
        /// </summary>
        public bool DisplayOperationId { get; set; } = false;

        /// <summary>
        /// The default expansion depth for models (set to -1 completely hide the models)
        /// </summary>
        public int DefaultModelsExpandDepth { get; set; } = 1;

        /// <summary>
        /// The default expansion depth for the model on the model-example section
        /// </summary>
        public int DefaultModelExpandDepth { get; set; } = 1;

        /// <summary>
        /// Controls the display of the request duration (in milliseconds) for Try-It-Out requests
        /// </summary>
        public bool DisplayRequestDuration { get; set; } = false;

        /// <summary>
        /// If set, enables filtering. The top bar will show an edit box that you can use to filter the tagged operations
        /// that are shown. Can be an empty string or specific value, in which case filtering will be enabled using that
        /// value as the filter expression. Filtering is case sensitive matching the filter expression anywhere inside the tag
        /// </summary>
        public string Filter { get; set; } = null;

        /// <summary>
        /// If set, limits the number of tagged operations displayed to at most this many. The default is to show all operations
        /// </summary>
        public int? MaxDisplayedTags { get; set; } = null;

        /// <summary>
        /// Controls the display of vendor extension (x-) fields and values for Operations, Parameters, and Schema
        /// </summary>
        public bool ShowExtensions { get; set; } = false;

        /// <summary>
        /// Controls the display of extensions (pattern, maxLength, minLength, maximum, minimum) fields and values for Parameters
        /// </summary>
        public bool ShowCommonExtensions { get; set; } = false;

        
        /// <summary>
        /// OAuth redirect URL
        /// </summary>
        [JsonProperty("oauth2RedirectUrl")]
        public string OAuth2RedirectUrl { get; set; } = null;

        /// <summary>
        /// By default, Swagger-UI attempts to validate specs against swagger.io's online validator.
        /// You can use this parameter to set a different validator URL, for example for locally deployed validators (Validator Badge).
        /// Setting it to null will disable validation
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string ValidatorUrl { get; set; } = null;

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalItems = new Dictionary<string, object>();

        #endregion Properties
    }
}