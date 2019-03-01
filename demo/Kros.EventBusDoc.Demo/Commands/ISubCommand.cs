using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Commands
{
    public interface ISubCommand<T> where T : ISubEvent
    {
        T MainEvent { get; set; }
    }
}
