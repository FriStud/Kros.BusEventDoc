using Kros.EventBusDoc.Demo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Services.Events
{
    /// <summary>
    /// Message event used ammong two correspondent.
    /// </summary>
    /// <remarks>
    ///Messaging event use  out of the scoper of demo web api
    /// </remarks>
    public interface IMessageEvent
    {
        ICorrespondent Sender { get; set; }
        ICorrespondent Receiver { get; set; }
    }
}
