namespace Kros.EventBusDoc.Demo.EmailProvider
{
    /// <summary>
    /// Email view model for mailing.
    /// </summary>
    public class EmailViewModel
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string subject { get; set; }
    }
}