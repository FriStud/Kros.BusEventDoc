using System;
using System.Collections.Generic;
using System.Reflection;

namespace Kros.EventBusDoc.Generator.BusentScour.Scourers
{
    /// <summary>
    /// Contract for looking for the consumers and the publishers.
    /// </summary>
    public interface IScourer
    {
        Assembly ExecutionAssembly { get; }
        IList<Type> Events { get; }
        IList<Type> Commands { get; }
        IList<Type> Consumes { get; }
        IList<Type> ResolvedTypes { get; }

        void Scour();
    }
}