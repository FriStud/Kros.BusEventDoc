using Kros.EventBusDoc.Generator.BusentAnnotation;
using System.Collections.Generic;
using System.Linq;

namespace Kros.EventBusDoc.Generator.BusentScour.Scourers
{
    internal class DeclarativeScourer : ScourerBase
    {
        public DeclarativeScourer(IAttributeFetcher attributeFetcher) : base(attributeFetcher)
        {
        }

        /// <summary>
        /// Scour with declarative principle
        /// </summary>
        /// <param name="enumerable"></param>
        protected override void ScourCore(IEnumerable<EventBusBaseAttribute> enumerable)
        {
            foreach (var item in enumerable.Where(t => t.GetType() != typeof(EventBusAssemblyScourAttribute)))
            {
                if (item is EventBusEventAttribute)
                {
                    Events.Add(item.EventType);
                }
                else if (item is EventBusCommandAttribute)
                {
                    Commands.Add(item.EventType);
                }
                else if (item is EventBusConsumerAttribute)
                {
                    Consumes.Add(item.EventType);
                }
            }
        }
    }
}