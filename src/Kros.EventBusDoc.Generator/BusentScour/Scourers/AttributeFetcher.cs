using Kros.EventBusDoc.Generator.BusentAnnotation;
using System.Collections.Generic;
using System.Reflection;

namespace Kros.EventBusDoc.Generator.BusentScour.Scourers
{
    internal class AttributeFetcher : IAttributeFetcher
    {
        #region Properties

        public Assembly ExecutionAssembly { get; }

        #endregion // end of Properties

        #region Consturctors

        public AttributeFetcher()
        {
            ExecutionAssembly = Assembly.GetEntryAssembly();
        }

        #endregion // end of Consturctors

        #region Member Functions

        public virtual IEnumerable<EventBusBaseAttribute> FetchAssemblyAttributes() =>
            ExecutionAssembly.GetCustomAttributes<EventBusBaseAttribute>();

        #endregion // end of Member Functions
    }
}