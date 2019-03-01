using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.MessageService.Interfaces
{
    public interface ICorrespondent
    {
        string Name { get; set; }
        string RegistrationNumber { get; set; }
        string Address { get; set; }

    }
}
