using Kros.EventBusDoc.Demo.EmailProvider;
using Kros.EventBusDoc.Demo.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Notifications
{
    /// <summary>
    /// Notify user.
    /// </summary>
    public interface IOrderNotificationEvent
    {
        Order TargetOrder { get; set; }
        IEmailSender EmailProvider { get; set; }
    }
}
