using System;

namespace Kros.EventBusDoc.Generator.BusentAnnotation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public class EventBusAttribute : EventBusBaseAttribute
    {
    }
}