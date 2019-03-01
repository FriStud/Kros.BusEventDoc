using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.EmailProvider
{
    /// <summary>
    /// EMail sender.
    /// </summary>
    /// <remarks>
    /// Use this service in scope of this demo.
    /// </remarks>
    public interface IEmailSender
    {
        Task SendMailAsync(EmailViewModel email);
    }
}
