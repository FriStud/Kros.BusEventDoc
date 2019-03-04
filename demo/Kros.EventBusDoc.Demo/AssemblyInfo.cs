using Kros.EventBusDoc.Demo.EmailProvider;
using Kros.EventBusDoc.Demo.Notifications;
using Kros.EventBusDoc.Demo.Services.Commands;
using Kros.EventBusDoc.Demo.Services.Events;
using Kros.EventBusDoc.Generator.BusentAnnotation;

[assembly: EventBusCommandSender(EventType = typeof(IEmailSender))]
[assembly: BusEvent(EventType = typeof(IOrderNotificationEvent))]
[assembly: BusEvent(EventType = typeof(IMessageEvent))]
[assembly: EventBusCommandConsumer(EventType = typeof(IMessageCommand))]
[assembly: EventBusCommandConsumer(EventType = typeof(CancelOrderCommand))]

