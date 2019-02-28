using System.Collections.Generic;

namespace Kros.EvenBusDoc.Generator.Test.resources.Types
{
    public class ComplexClass
    {
        public SimpleClass[] ArrayOfSimpleClass { get; set; }

        public IDictionary<int, SimpleClass> DicitonaryType { get; set; }
    }
}