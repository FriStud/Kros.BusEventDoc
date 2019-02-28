using System;
using System.IO;
using System.Reflection;
using System.Xml;
using Kros.EventBusDoc.Generator.Helpers;

namespace Kros.EventBusDoc.Generator.BusentScour.XmlReader
{
    internal class XmlDocumentationReader : IXmlDocumentationReader
    {
        #region Properties

        public XmlDocument Document { get; private set; }

        #endregion Properties

        #region Member Functions

        public void Load(string documentPath)
        {
            Document = new XmlDocument();
            Document.Load(documentPath);
        }

        public void Load(Stream inStream)
        {
            Document = new XmlDocument();
            Document.Load(inStream);
        }

        public string GetSummary(Type type, PropertyInfo property = null) =>
            GetInnerElementString(type, XmlDocumentationType.Summary, property);

        public string GetRemarks(Type type, PropertyInfo property = null) =>
            GetInnerElementString(type, XmlDocumentationType.Remarks, property);

        private string GetInnerElementString(Type type, XmlDocumentationType tag, PropertyInfo property = null) =>
            GetElement(type, property)?.SelectSingleNode(tag.GetEnumDescription().ToLower())
            is XmlNode summa ? summa.InnerText.Trim() : "";

        private XmlElement GetElement(Type type, PropertyInfo property = null)
        {
            XmlElement element;
            if (property == null)
            {
                element = type.GetDocumentation(Document);
            }
            else
            {
                element = property.GetPropertyDocumentation(type, Document);
            }

            return element;
        }

        public void LoadXml(string xml)
        {
            Document = new XmlDocument();
            Document.LoadXml(xml);
        }

        #endregion Member Functions
    }
}