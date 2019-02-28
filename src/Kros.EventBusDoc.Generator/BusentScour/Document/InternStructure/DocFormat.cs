using System.Collections.Generic;

namespace Kros.EventBusDoc.Generator.BusentScour.Document.InternStructure
{
    public class DocFormat
    {
        public string MiddleWareVersion { get; set; }
        public Service Service { get; set; }
        public IList<MessageDefinition> Definitions { get; set; }
        public IList<DescriptiveType> Types { get; set; }

        public DocFormat()
        {
            Definitions = new List<MessageDefinition>();
            Types = new List<DescriptiveType>();
        }
    }
}