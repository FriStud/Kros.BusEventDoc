using Kros.EventBusDoc.Demo.Services.Interfaces;

namespace Kros.EventBusDoc.Demo.Services.Commands
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
