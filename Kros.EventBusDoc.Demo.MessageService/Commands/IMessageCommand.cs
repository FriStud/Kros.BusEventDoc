using Kros.EventBusDoc.Demo.MessageService.Interfaces;

namespace Kros.EventBusDoc.Demo.MessageService.Commands
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
