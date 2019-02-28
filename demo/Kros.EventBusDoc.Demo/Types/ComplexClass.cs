using System.Collections.Generic;

namespace Kros.EventBusDoc.Demo.Types
{
    public class ComplexClass
    {
        public SimpleClass[] ArrayOfSimpleClass { get; set; }

        public IDictionary<int, SimpleClass> DicitonaryType { get; set; }
    }
}