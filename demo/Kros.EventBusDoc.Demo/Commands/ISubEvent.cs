using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Commands
{
    public interface ISubEvent
    {
        void OnRaised();
    }
}
