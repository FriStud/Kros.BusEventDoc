using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.EmailProvider
{
    public class EmailSender : IEmailSender
    {
        public Task SendMailAsync(EmailViewModel email)
        {
            throw new NotImplementedException("SendMailAsync Not Implemented.");
        }
    }
}
