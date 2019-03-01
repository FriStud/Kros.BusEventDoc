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
    public interface IEmailSender
    {
        Task SendMailAsync(EmailViewModel email);
    }
}
