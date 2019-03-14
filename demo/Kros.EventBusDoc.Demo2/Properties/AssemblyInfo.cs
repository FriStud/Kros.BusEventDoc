using Kros.EventBusDoc.Demo.Contracts.Events;
using Kros.EventBusDoc.Generator.BusentAnnotation;

[assembly: EventBusEvent(EventType = typeof(IMessageEvent))]