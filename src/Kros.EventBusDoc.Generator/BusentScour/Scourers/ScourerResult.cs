using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Generator.BusentScour.Scourers
{
    public class ScourerResult
    {
        public IList<Type> Events { get; } = new List<Type>();

        public IList<Type> Commands { get; } = new List<Type>();

        public IList<Type> Consumes { get; } = new List<Type>();

        public IList<Type> ResolvedTypes { get; } = new List<Type>();
    }
}
