namespace Kros.EventBusDoc.Demo.Types
{
    /// <summary>
    /// Generic class withT
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericClass<T>
    {
        /// <summary>
        /// The generic argument
        /// </summary>
        public T GenericClassArgument { get; set; }

        /// <summary>
        /// Simple class in generic class
        /// </summary>
        public SimpleClass InGenericSimpleClass { get; set; }

        /// <summary>
        /// Description of generic class
        /// </summary>
        public string GenericDescription { get; set; }
    }
}