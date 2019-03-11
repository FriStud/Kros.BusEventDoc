using Kros.EventBusDoc.Generator.BusentAnnotation;
using System.Collections.Generic;
using System.Reflection;

namespace Kros.EventBusDoc.Generator.BusentScour.Scourers
{
    public interface IAttributeFetcher
    {
        Assembly ExecutionAssembly { get; }

        IEnumerable<EventBusBaseAttribute> FetchAssemblyAttributes();
    }
}