using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Commands
{
    /// <summary>
    /// Concrete implementation of SubEvent.
    /// </summary>
    public class SubEvent : ISubEvent
    {
        public void OnRaised()
        {
            throw new NotImplementedException();
        }
    }
}
