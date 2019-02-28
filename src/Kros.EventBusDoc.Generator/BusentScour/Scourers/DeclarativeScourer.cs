using Kros.EventBusDoc.Generator.BusentAnnotation;
using Kros.EventBusDoc.Generator.BusentScour.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Kros.EventBusDoc.Generator.Helpers;

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
                if (item is BusEvent)
                {
                    Events.Add(item.EventType);
                }
                else if (item is EventBusCommandSenderAttribute)
                {
                    Commands.Add(item.EventType);
                }
                else if (item is EventBusConsumerAttribute || item is EventBusCommandConsumerAttribute)
                {
                    Consumes.Add(item.EventType);
                }
            }
        }
    }
}