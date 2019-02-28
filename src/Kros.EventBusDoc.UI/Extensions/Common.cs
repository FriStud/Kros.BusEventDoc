using System.IO;
using System.Reflection;

namespace Kros.EventBusDoc.UI.Extensions
{
    public static class Common
    {
        /// <summary>
        /// From the this file path get stream of the file. Refering file has to be configured as a embedded resource.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="specific"></param>
        /// <returns>Stream of file otherwise null</returns>
        public static Stream GetEmbeddedFileStream(this string filePath, Assembly specific = null)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName().Name;

            return specific == null ? assembly.GetManifestResourceStream(assemblyName + "." + filePath)
                :
                specific.GetManifestResourceStream(specific.GetName().Name + "." + filePath);
        }
    }
}