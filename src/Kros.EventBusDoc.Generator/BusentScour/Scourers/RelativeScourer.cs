using Kros.EventBusDoc.Generator.BusentAnnotation;
using Kros.EventBusDoc.Generator.BusentScour.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kros.EventBusDoc.Generator.BusentScour.Scourers
{
    // binds the service with all that ask for its service
    using Bindings = KeyValuePair<Type, IList<Type>>;

    internal class RelativeScourer : ScourerBase
    {
        #region Properies

        private IEnumerable<Type> _services;
        private IEnumerable<Type> _consumer;
        public IDictionary<Type, IList<Type>> MatchConsumerService { get; set; }

        #endregion Properies

        #region Constructors

        public RelativeScourer(IAttributeFetcher attributeFetcher) : base(attributeFetcher)
        {
        }

        #endregion Constructors

        #region Member Functions

        /// <summary>
        /// Finds all types that are registerd/tagged bythe specific attribute
        /// </summary>
        /// <param name="assemblyAttribute">Assembly attribute</param>
        private void FindServices(EventBusAssemblyScourAttribute assemblyAttribute)
        {
            _services = FindByAttributeTypeIn(typeof(EventBusPublisherAttribute), assemblyAttribute.ServiceDir);
        }

        /// <summary>
        /// Finds all types that are register/tagged by the specific attribute
        /// </summary>
        /// <param name="assemblyAttribute"></param>
        private void Findconsumers(EventBusAssemblyScourAttribute assemblyAttribute)
        {
            _consumer = FindByAttributeTypeIn(typeof(EventBusAssemblyScourAttribute), assemblyAttribute.ConsumerDir);
        }

        /// <summary>
        /// Finds only tagged types, if defined pattern then in specify otherwise scour all assembly
        /// </summary>
        /// <param name="attributeType"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private IEnumerable<Type> FindByAttributeTypeIn(Type attributeType, string pattern)
        {
            if (!string.IsNullOrWhiteSpace(pattern))
            {
                return ExecutionAssembly.DefinedTypes
                    .Where(o => o.Namespace.StartsWith(pattern) && o.GetCustomAttribute(attributeType) != null);
            }
            else
            {
                return ExecutionAssembly.DefinedTypes
                    .Where(info => info.GetCustomAttribute(attributeType) != null);
            }
        }

        /// <summary>
        /// Search for the service and their consumers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Bindings> MatchSserviceAndConsumer()
        {
            Scour();

            foreach (var item in _consumer)
            {
                foreach (var iC in item.GetInterfaces().Where(o => o.GetInterfaces().Contains(typeof(IConsumer))))
                {
                    Bindings pair = new Bindings(iC, new List<Type>());
                    foreach (var publisher in _services)
                    {
                        if (HasPublishTagWithType(publisher, iC.GenericTypeArguments.FirstOrDefault()))
                        {
                            pair.Value.Add(publisher);
                        }
                    }
                    yield return pair;
                }
            }
        }

        /// <summary>
        /// Checks if the the tagged methods by EType
        /// has the appropriate published type.
        /// </summary>
        /// <param name="publisher"></param>
        /// <param name="pulished"></param>
        /// <returns></returns>
        private bool HasPublishTagWithType(Type publisher, Type pulished)
        {
            return publisher.GetMethods()
                .ToList()
                .Where(x => x.GetCustomAttributes<EType>()
                    .Where(o => o.EventType == pulished).Count() > 0)
                .Count() > 0;
        }

        public void RegisterType(Type @object)
        {
            throw new NotImplementedException();
        }

        protected override void ScourCore(IEnumerable<EventBusBaseAttribute> enumerable)
        {
            if (HasAssemblyScourInstruction() is EventBusAssemblyScourAttribute assemblyAttr)
            {
                if (assemblyAttr.EnableScourOfTags)
                {
                    FindServices(assemblyAttr);
                    Findconsumers(assemblyAttr);
                }
            }
        }

        #endregion Member Functions
    }
}