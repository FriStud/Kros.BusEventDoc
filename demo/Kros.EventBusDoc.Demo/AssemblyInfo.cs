using Kros.EventBusDoc.Demo.EmailProvider;
using Kros.EventBusDoc.Generator.BusentAnnotation;

[assembly: EventBusCommandSender(EventType = typeof(IEmailSender))]

