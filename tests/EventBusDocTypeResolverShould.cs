using FluentAssertions;
using Kros.EvenBusDoc.Generator.Test.resources.Types;
using Kros.EventBusDoc.Generator.BusentAnnotation;
using Kros.EventBusDoc.Generator.BusentScour.Scourers;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace Kros.EvenBusDoc.Generator.Test
{
    public class EventBusDocTypeResolverShould
    {
        private readonly IScourer _scourer;

        #region Initialization for tests
        public EventBusDocTypeResolverShould()
        {
            _scourer = new DeclarativeScourer(ConfigureDummyFetcher());
        }

        private IAttributeFetcher ConfigureDummyFetcher()
        {
            var fetcher = Substitute.For<IAttributeFetcher>();
            fetcher.FetchAssemblyAttributes().Returns(new List<EventBusBaseAttribute>()
                {
                    new EventBusEventAttribute(){EventType = typeof(ISnedEvent)},
                    new EventBusCommandAttribute(){ EventType = typeof(ISendCommand)},
                    new EventBusConsumerAttribute(){EventType = typeof(IConsumeOne)},
                    new EventBusConsumerAttribute(){EventType = typeof(IConsumeTwo)},
                    new EventBusEventAttribute(){ EventType = typeof(EventFor2)}
                });

            return fetcher;
        }

        #endregion Initialization for tests

        #region Tests For Collections Events, Commands, ResolvedTypes

        [Fact]
        public void ScourerHaveEvents()
        {
            var eventsList = new List<Type>() {
                typeof(ISnedEvent),
                typeof(EventFor2)
            };

            _scourer.Scour();

            eventsList.Should().BeEquivalentTo(_scourer.Events);
        }

        [Fact]
        public void ScourerHaveCommands()
        {
            var commandList = new List<Type>() {
                typeof(ISendCommand)
            };

            _scourer.Scour();

            commandList.Should().BeEquivalentTo(_scourer.Commands);
        }

        [Fact]
        public void ScourerConsumes()
        {
            var commandList = new List<Type>() {
                typeof(IConsumeTwo),
                typeof(IConsumeOne)
            };

            _scourer.Scour();

            commandList.Should().BeEquivalentTo(_scourer.Consumes);
        }

        [Fact]
        public void ScourerHasResolvedTypes()
        {
            var subjectList = new List<Type>() {
                typeof(ISnedEvent),
                typeof(SimpleClass),
                typeof(InSigthOfEventType),
                typeof(ComplexClass),
                typeof(GenericClass<GenericArgument>),
                typeof(GenericClass<GenericArgument2>),
                typeof(GenericArgument),
                typeof(GenericArgument2),
                typeof(ISendCommand),
                typeof(IConsumeOne),
                typeof(IConsumeTwo),
                typeof(EventFor2),
            };

            _scourer.Scour();

            subjectList.Should().BeEquivalentTo(_scourer.ResolvedTypes);
        }

        #endregion Tests For Collections Events, Commands, ResolvedTypes


    }
}