using Kros.EventBusDoc.Demo.EmailProvider;
using Kros.EventBusDoc.Generator.BusentAnnotation;
using Kros.EventBusDoc.Demo.MessageService.Events;
using Kros.EventBusDoc.Demo.Notifications;
using Kros.EventBusDoc.Demo.Commands;

[assembly: EventBusCommandSender(EventType = typeof(IEmailSender))]
[assembly: BusEvent(EventType = typeof(IOrderNotificationEvent))]
[assembly: BusEvent(EventType = typeof(IMessageEvent))]
[assembly: EventBusCommandSender(EventType = typeof(ICancelOrderCommand<ISubEvent>))]

