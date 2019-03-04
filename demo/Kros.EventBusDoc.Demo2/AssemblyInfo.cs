using Kros.EventBusDoc.Demo.Services.Events;
using Kros.EventBusDoc.Generator.BusentAnnotation;

[assembly: BusEvent(EventType = typeof(IMessageEvent))]