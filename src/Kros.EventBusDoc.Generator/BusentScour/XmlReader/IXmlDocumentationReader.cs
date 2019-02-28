using System;
using System.IO;
using System.Reflection;

namespace Kros.EventBusDoc.Generator.BusentScour.XmlReader
{
    internal interface IXmlDocumentationReader
    {
        string GetSummary(Type type, PropertyInfo property = null);

        string GetRemarks(Type type, PropertyInfo property = null);

        void Load(string filePath);

        void Load(Stream inStream);

        void LoadXml(string xml);
    }
}