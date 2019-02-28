namespace Kros.EventBusDoc.Demo.Types
{
    /// <summary>
    /// Sending Event interface
    /// </summary>
    /// <remarks>
    /// This has some Additionl data
    /// </remarks>
    public interface ISendEvent
    {
        SimpleClass SimpleObject { get; set; }

        /// <summary>
        /// Summary for the Property of ISendEvent of InsightofEventType
        /// </summary>
        /// <remarks>
        /// DATA for the property
        /// </remarks>
        InSigthOfEventType InterfaceInEvent { get; set; }

        ComplexClass ComplexObject { get; set; }
        GenericClass<GenericArgument> SimpleGenericClass { get; set; }
        GenericClass<GenericArgument2>[] ArrayOfGenericClass { get; set; }
    }
}