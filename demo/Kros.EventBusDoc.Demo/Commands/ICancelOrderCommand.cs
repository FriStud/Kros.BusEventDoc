using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kros.EventBusDoc.Demo.Commands
{
    public interface ICancelOrderCommand<T> : ICommand where T : ISubEvent
    {
        ISubCommand<T>[] EventAfterExecute { get; set; }
    }
}
