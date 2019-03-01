using Kros.EventBusDoc.Demo.MessageService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.MessageService.Events
{
    /// <summary>
    /// Message event used ammong two correspondent.
    /// </summary>
    public interface IMessageEvent
    {
        ICorrespondent Sender { get; set; }
        ICorrespondent Receiver { get; set; }
    }
}
