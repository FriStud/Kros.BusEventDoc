using Kros.EventBusDoc.Demo.Contracts.Commands;
using Kros.EventBusDoc.Demo.Contracts.Events;
using Kros.EventBusDoc.Demo.EmailProvider;
using Kros.EventBusDoc.Demo.Notifications;
using Kros.EventBusDoc.Generator.BusentAnnotation;

[assembly: EventBusCommand(EventType = typeof(IEmailSender))]
[assembly: EventBusEvent(EventType = typeof(IOrderNotificationEvent))]
[assembly: EventBusEvent(EventType = typeof(IMessageEvent))]
[assembly: EventBusConsumer(EventType = typeof(IMessageCommand))]
[assembly: EventBusConsumer(EventType = typeof(CancelOrderCommand))]

