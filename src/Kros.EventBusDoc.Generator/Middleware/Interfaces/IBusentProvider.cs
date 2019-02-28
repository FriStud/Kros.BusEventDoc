using Kros.EventBusDoc.Generator.BusentScour.Document.InternStructure;
using Newtonsoft.Json;

namespace Kros.EventBusDoc.Generator.Middleware.Interfaces
{
    public interface IBusentProvider
    {
        DocFormat Document { get; set; }

        string Serialize(JsonSerializerSettings settings = null);
    }
}