using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kros.EventBusDoc.Generator.BusentScour.XmlReader;

namespace Kros.EventBusDoc.Generator.Helpers
{
    internal static class TypeExtensions
    {
        public static MethodInfo GetMehodWithTag(this Type type, Type tagType)
        {
            var methods = type.GetMethods().Where(method => method.GetCustomAttribute(tagType) != null);

            return null;
        }

        public static bool IsImplementedInterface(this Type type, Type @interface)
        {
            return type.GetInterfaces().Contains(@interface);
        }

        /// <summary>
        /// Get the name of type, it consider if it is a collection to format the string looks better
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetName(this Type type)
        {
            if (type.IsArray && (type != typeof(string)))
            {
                return GetNameForArray(type);
            }

            if (type.IsGenericType && (type != typeof(string)))
            {
                if (!type.IsArray)
                {
                    return type.Name.GetGenericName(type.GetGenericArguments());
                }
            }

            return type.Name;
        }

        private static string GetNameForArray(Type type)
        {
            var arrayType = type.GetElementType();
            var name = arrayType.Name;

            if (arrayType.IsGenericType)
            {
                name = arrayType.Namespace + arrayType.Name.GetGenericName(arrayType.GetGenericArguments());
            }

            return $"{name}[]";
        }

        public static string GetFullName(this Type type)
        {
            if (type.IsArray && (type != typeof(string)))
            {
                return GetNameForArray(type);
            }

            if (type.IsGenericType && (type != typeof(string)))
            {
                if (!type.IsArray)
                {
                    return type.FullName.GetGenericName(type.GetGenericArguments());
                }
                return type.FullName;
            }
            else
            {
                return type.FullName;
            }
        }

        /// <summary>
        /// Nesty workaround to get the neat type of collections.
        /// </summary>
        /// <param name="givenName"></param>
        /// <param name="genericArguments"></param>
        /// <returns></returns>
        private static string GetGenericName(this string givenName, params Type[] genericArguments)
        {
            if (givenName.Split('`').FirstOrDefault() is string @base)
            {
                @base += "<";

                foreach (var item in (from argument in genericArguments select argument.Name))
                {
                    @base += $"{item},";
                }

                givenName = new string(@base.Take(@base.Length - 1).ToArray()) + ">";
            }

            return givenName;
        }

        public static string GetEnumDescription(this Enum @enum) =>
            @enum.GetType().GetField(@enum.ToString()).GetCustomAttributes(typeof(XmlTypeAttribute)).FirstOrDefault()
                is XmlTypeAttribute description ? description.Description : @enum.ToString();

    }
}