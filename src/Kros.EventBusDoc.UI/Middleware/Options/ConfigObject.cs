using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kros.EventBusDoc.UI.Middleware.Options
{
    /// <summary>
    /// Used for data to pass to UI, configuration
    /// </summary>
    public class ConfigObject
    {
        #region Properties

        /// <summary>
        /// One or more EvntBusDoc JSON endpoints (url and name) to power the UI
        /// </summary>
        public List<UrlDescriptor> Urls { get; internal set; }

        #endregion Properties
    }
}