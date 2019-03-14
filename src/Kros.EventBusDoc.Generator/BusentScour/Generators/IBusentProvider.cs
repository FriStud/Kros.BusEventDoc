using Kros.EventBusDoc.Generator.BusentScour.Document;
using Newtonsoft.Json;

namespace Kros.EventBusDoc.Generator.BusentScour.Generators
{
    public interface IBusentProvider
    {
        DocFormat Document { get; set; }

        string Serialize(ServiceSettings serviceSettings, JsonSerializerSettings settings = null);
    }
}