using Kros.EventBusDoc.Demo.Services.Events;
using Kros.EventBusDoc.Generator.BusentAnnotation;

[assembly: EventBusEvent(EventType = typeof(IMessageEvent))]