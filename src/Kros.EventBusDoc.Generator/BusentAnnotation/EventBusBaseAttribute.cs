using System;
using System.Collections.Generic;

namespace Kros.EventBusDoc.Generator.BusentAnnotation
{

    public abstract class EventBusBaseAttribute : Attribute
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public Type EventType { get; set; }
    }
}