using FluentAssertions;
using Kros.EvenBusDoc.Generator.Test.resources;
using Kros.EvenBusDoc.Generator.Test.resources.Types;
using Kros.EventBusDoc.Generator.BusentScour.XmlReader;
using System;
using Xunit;

namespace Kros.EvenBusDoc.Generator.Test
{

    public class EventBusDocXmlReaderShould
    {
        private IXmlDocumentationReader _xmlReader;

        public EventBusDocXmlReaderShould()
        {
            _xmlReader = new XmlDocumentationReader();
            _xmlReader.LoadXml(Resources.Kros_EvenBusDoc_Generator_Test);
        }

        #region Inline Tests For Reading Summary & Remarks From Xml

        [Theory]
        [InlineData(typeof(ISnedEvent), "Sending Event interface")]
        [InlineData(typeof(GenericClass<int>), "Generic class withT")]
        public void HaveAnyClassASummary(Type classType, string expected) =>
            _xmlReader.GetSummary(classType).Should().Be(expected);

        [Theory]
        [InlineData(typeof(ISnedEvent), "This has some Additionl data")]
        [InlineData(typeof(GenericClass<int>), "")]
        public void HaveAnyClassARemark(Type classType, string expected) =>
            _xmlReader.GetRemarks(classType).Should().Be(expected);

        [Theory]
        [InlineData(typeof(ISnedEvent), "InterfaceInEvent", "Summary for the Property of ISendEvent of InsightofEventType")]
        [InlineData(typeof(ISnedEvent), "ComplexObject", "")]
        [InlineData(typeof(GenericClass<int>), "GenericClassArgument", "The generic argument")]
        public void HaveAnyClassPropertySummary(Type classType, string propertyName, string expected) =>
            _xmlReader.GetSummary(classType, classType.GetProperty(propertyName)).Should().Be(expected);

        #endregion Inline Tests For Reading Summary & Remarks From Xml
    }

}
