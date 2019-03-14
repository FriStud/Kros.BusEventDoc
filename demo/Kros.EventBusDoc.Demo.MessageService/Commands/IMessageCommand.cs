
using Kros.EventBusDoc.Demo.Contracts.Interfaces;

namespace Kros.EventBusDoc.Demo.Contracts.Commands
{
    /// <summary>
    /// Message commad out of the demo scope api.
    /// </summary>
    public interface IMessageCommand
    {
        /// <summary>
        /// The target.
        /// </summary>
        ICorrespondent Correspondent { get; set; }
        void OnExecute();
    }
}
