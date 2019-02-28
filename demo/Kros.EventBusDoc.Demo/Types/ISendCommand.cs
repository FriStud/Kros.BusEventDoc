namespace Kros.EventBusDoc.Demo.Types
{
    /// <summary>
    /// Send command interface
    /// </summary>
    public interface ISendCommand
    {
        string SendCommand { get; set; }
    }
}