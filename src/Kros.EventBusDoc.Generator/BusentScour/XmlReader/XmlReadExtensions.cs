using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Kros.EventBusDoc.Generator.Helpers;

namespace Kros.EventBusDoc.Generator.BusentScour.XmlReader
{
    internal static class XmlReadExtensions
    {
        private const string prefix = "file:///";

        public static XmlElement GetDocumentation(this Type type, XmlDocument xmlDocument) =>
            XmlFromName(type, XmlDocumentationType.Class, "", xmlDocument);

        public static XmlElement GetPropertyDocumentation(this PropertyInfo property, Type type, XmlDocument xmlDocument) =>
            XmlFromName(type, XmlDocumentationType.Property, property.Name, xmlDocument);

        private static XmlElement XmlFromName(Type type, XmlDocumentationType prefix, string name, XmlDocument xmlDocument)
        {
            string fullName;
            string TypeFullName = type.FullName.Split("[").First();

            if (string.IsNullOrEmpty(name))
                fullName = $"{prefix.GetEnumDescription()}:{TypeFullName}";
            else
                fullName = $"{prefix.GetEnumDescription()}:{TypeFullName}.{name}";

            var matchedElement = xmlDocument["doc"]["members"].SelectSingleNode("member[@name='" + fullName + "']") as XmlElement;

            return matchedElement;
        }

        public static string GetDocumentPath(this Assembly assembly) =>
            Path.ChangeExtension(assembly.CodeBase.Substring(prefix.Length), ".xml");
    }
}