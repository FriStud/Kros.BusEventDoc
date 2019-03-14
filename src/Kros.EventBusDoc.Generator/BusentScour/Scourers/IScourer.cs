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

        ScourerResult Scour();
    }
}