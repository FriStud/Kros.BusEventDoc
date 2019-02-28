using Kros.EventBusDoc.Generator.BusentScour.Generators;

namespace Kros.EventBusDoc.Generator.Middleware.Extensions
{
    public static class EventBusDocGenOptionExtensions
    {
        /// <summary>
        /// Define one or more documents to be created by the generator
        /// </summary>
        /// <param name="genOptions"></param>
        /// <param name="name">A URI-friendly name that uniquely identifies the document</param>
        /// <param name="info">Global metadata to be included in the Swagger output</param>
        public static void EventBusDoc(
            this EventBusDocGenOptions genOptions,
            string name,
            Info info)
        {
            genOptions.EventBusDocs.Add(name, info);
        }
    }
}