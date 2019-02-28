using Kros.EventBusDoc.Generator.BusentAnnotation;
using Kros.EventBusDoc.Generator.BusentScour.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Kros.EventBusDoc.Generator.BusentScour.Scourers
{
    internal abstract class ScourerBase : IScourer
    {
        private readonly IAttributeFetcher _attributeFetcher;

        #region Constructors

        public ScourerBase(IAttributeFetcher attributeFetcher)
        {
            _attributeFetcher = attributeFetcher;
        }

        #endregion Constructors

        #region Properties

        public Assembly ExecutionAssembly { get => _attributeFetcher.ExecutionAssembly; }

        public IList<Type> Events { get; } = new List<Type>();

        public IList<Type> Commands { get; } = new List<Type>();

        public IList<Type> Consumes { get; } = new List<Type>();

        public IList<Type> ResolvedTypes { get; } = new List<Type>();

        public IList<Type> IgnoreTypes { get; } = new List<Type>();

        #endregion Properties

        #region Member Functions

        public void Scour()
        {
            Clear();
            ScourCore(_attributeFetcher.FetchAssemblyAttributes());
            ResolveAllTypes();
        }

        private void Clear()
        {
            Events.Clear();
            Commands.Clear();
            Consumes.Clear();
            ResolvedTypes.Clear();
        }

        protected abstract void ScourCore(IEnumerable<EventBusBaseAttribute> enumerable);

        private void ResolveAllTypes()
        {
            foreach (var typ in Events)
            {
                RegisterAllTypes(typ);
            }

            foreach (var typ in Commands)
            {
                RegisterAllTypes(typ);
            }

            foreach (var typ in Consumes)
            {
                RegisterAllTypes(typ);
            }
        }

        private void RegisterAllTypes(Type type)
        {
            if (!OmitThisType(type))
            {
                if (type.IsGenericType)
                {
                    HandleGenericType(type);
                }
                else if (type.IsArray)
                {
                    RegisterAllTypes(type.GetElementType());
                }
                else
                {
                    RegisterTypeWithProperties(type);
                }
            }
        }

        private void RegisterTypeWithProperties(Type type)
        {
            RegisterType(type);
            foreach (var proper in type.GetProperties())
            {
                RegisterAllTypes(proper.PropertyType);
            }
        }

        private void HandleGenericType(Type type)
        {
            if (!IsFromSystemAndGeneric(type))
            {
                RegisterTypeWithProperties(type);
            }

            foreach (var arg in type.GetGenericArguments())
            {
                RegisterAllTypes(arg);
            }
        }

        private bool OmitThisType(Type type) =>
            (type.IsPrimitive || IsRegistered(type) ||
            (type.BaseType is null && !type.IsInterface) || (type == typeof(string)))
            ? true
            : false;

        private bool IsFromSystemAndGeneric(Type type) =>
            type.AssemblyQualifiedName.StartsWith("System.Collections.Generic");

        private void RegisterType(Type propType) =>
            ResolvedTypes.Add(propType);

        private bool IsRegistered(Type type) =>
            ResolvedTypes.Contains(type);

        protected EventBusAssemblyScourAttribute HasAssemblyScourInstruction() =>
            ExecutionAssembly.GetCustomAttribute<EventBusAssemblyScourAttribute>();

        #endregion Member Functions

    }
}