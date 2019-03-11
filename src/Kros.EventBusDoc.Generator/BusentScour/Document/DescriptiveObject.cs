using System.Collections.Generic;

namespace Kros.EventBusDoc.Generator.BusentScour.Document
{
    public abstract class DescriptiveObject : Descpritive
    {
        public string FullName { get; set; }
        public IEnumerable<Property> Properties { get; set; }

        public DescriptiveObject()
        {
            Properties = new List<Property>();
        }
    }
}