using Kros.EventBusDoc.Generator.BusentScour.Generators;

namespace Kros.EventBusDoc.Generator.Middleware
{
    public static class EventBusDocGenOptionExtensions
    {
        /// <summary>
        /// Define document to be created by the generator
        /// </summary>
        /// <param name="genOptions"></param>
        /// <param name="name">A URI-friendly name that uniquely identifies the document</param>
        /// <param name="info">Global metadata to be included in the event bus doc output</param>
        public static void EventBusDoc(
            this EventBusDocGenOptions genOptions,
            string name,
            Info info)
        {
            genOptions.EventBusDocs.Add(name, info);
        }
    }
}