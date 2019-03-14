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
        /// <param name="scourerResult"></param>
        protected override void ScourCore(IEnumerable<EventBusBaseAttribute> enumerable, ScourerResult scourerResult)
        {
            foreach (var item in enumerable.Where(t => t.GetType() != typeof(EventBusAssemblyScourAttribute)))
            {
                if (item is EventBusEventAttribute)
                {
                    scourerResult.Events.Add(item.EventType);
                }
                else if (item is EventBusCommandAttribute)
                {
                    scourerResult.Commands.Add(item.EventType);
                }
                else if (item is EventBusConsumerAttribute)
                {
                    scourerResult.Consumes.Add(item.EventType);
                }
            }
        }
    }
}