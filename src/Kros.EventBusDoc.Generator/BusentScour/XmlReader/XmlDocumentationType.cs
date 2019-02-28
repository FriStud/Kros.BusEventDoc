namespace Kros.EventBusDoc.Generator.BusentScour.XmlReader
{
    internal enum XmlDocumentationType
    {
        [XmlType(Description = "none")]
        None = 0,

        /// <summary>
        /// marks a property in xml document
        /// </summary>
        [XmlType(Description = "P")]
        Property = 1,

        /// <summary>
        /// marks a class type in xml document
        /// </summary>
        [XmlType(Description = "T")]
        Class = 2,

        /// <summary>
        /// marks the summary in the xml document
        /// </summary>
        [XmlType(Description = "summary")]
        Summary = 4,

        /// <summary>
        /// marks the remarks in the xml document
        /// </summary>
        [XmlType(Description = "remarks")]
        Remarks = 8
    }
}