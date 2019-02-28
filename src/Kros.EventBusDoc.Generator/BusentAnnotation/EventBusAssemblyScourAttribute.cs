using System;

namespace Kros.EventBusDoc.Generator.BusentAnnotation
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class EventBusAssemblyScourAttribute : EventBusBaseAttribute
    {
        public bool EnableScourOfTags { get; set; }

        /// <summary>
        /// False result int searching the consumer by well-know inteface IConsumerTHEvent
        /// from namespace MassTransit
        /// </summary>
        public bool TaggedConsumer { get; set; }

        /// <summary>
        /// So far meant to be to look for only specified assembly directory
        /// </summary>
        public string ServiceDir { get; set; }

        /// <summary>
        /// Meant for static assigned to scour files
        /// </summary>
        public string ConsumerDir { get; set; }
    }
}