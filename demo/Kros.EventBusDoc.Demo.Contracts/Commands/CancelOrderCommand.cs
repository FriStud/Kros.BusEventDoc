using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Contracts.Commands
{
    public class CancelOrderCommand
    {
        public int OrderNumber { get; }

        public CancelOrderCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}
