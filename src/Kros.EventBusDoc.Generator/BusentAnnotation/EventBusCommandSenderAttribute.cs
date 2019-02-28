using System;

namespace Kros.EventBusDoc.Generator.BusentAnnotation
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EventBusCommandSenderAttribute : EventBusBaseAttribute
    {
    }
}