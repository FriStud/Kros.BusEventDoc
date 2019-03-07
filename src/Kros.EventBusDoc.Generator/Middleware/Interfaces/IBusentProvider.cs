using Kros.EventBusDoc.Generator.BusentScour.Document.InternStructure;
using Kros.EventBusDoc.Generator.BusentScour.Generators;
using Newtonsoft.Json;

namespace Kros.EventBusDoc.Generator.Middleware.Interfaces
{
    public interface IBusentProvider
    {
        DocFormat Document { get; set; }

        string Serialize(ServiceSettings serviceSettings, JsonSerializerSettings settings = null);
    }
}