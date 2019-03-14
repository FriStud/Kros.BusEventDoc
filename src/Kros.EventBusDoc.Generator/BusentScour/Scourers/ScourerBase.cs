using Kros.EventBusDoc.Generator.BusentAnnotation;
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

        public IList<Type> IgnoreTypes { get; } = new List<Type>();

        #endregion Properties

        #region Member Functions

        public ScourerResult Scour()
        {
            var _scourerResult = new ScourerResult();
            ScourCore(_attributeFetcher.FetchAssemblyAttributes(), _scourerResult);
            ResolveAllTypes(_scourerResult);
            return _scourerResult;
        }

        protected abstract void ScourCore(IEnumerable<EventBusBaseAttribute> enumerable, ScourerResult scourerResult);

        private void ResolveAllTypes(ScourerResult scourerResult)
        {
            foreach (var typ in scourerResult.Events)
            {
                RegisterAllTypes(typ, scourerResult);
            }

            foreach (var typ in scourerResult.Commands)
            {
                RegisterAllTypes(typ, scourerResult);
            }

            foreach (var typ in scourerResult.Consumes)
            {
                RegisterAllTypes(typ, scourerResult);
            }
        }

        private void RegisterAllTypes(Type type, ScourerResult scourerResult)
        {
            if (!OmitThisType(type, scourerResult))
            {
                if (type.IsGenericType)
                {
                    HandleGenericType(type, scourerResult);
                }
                else if (type.IsArray)
                {
                    RegisterAllTypes(type.GetElementType(), scourerResult);
                }
                else
                {
                    RegisterTypeWithProperties(type, scourerResult);
                }
            }
        }

        private void RegisterTypeWithProperties(Type type, ScourerResult scourerResult)
        {
            RegisterType(type, scourerResult);
            foreach (var proper in type.GetProperties())
            {
                RegisterAllTypes(proper.PropertyType, scourerResult);
            }
        }

        private void HandleGenericType(Type type, ScourerResult scourerResult)
        {
            if (!IsFromSystemAndGeneric(type))
            {
                RegisterTypeWithProperties(type, scourerResult);
            }

            foreach (var arg in type.GetGenericArguments())
            {
                RegisterAllTypes(arg, scourerResult);
            }
        }

        private bool OmitThisType(Type type, ScourerResult scourerResult) =>
            (type.IsPrimitive || IsRegistered(type, scourerResult) ||
            (type.BaseType is null && !type.IsInterface) || (type == typeof(string)))
            ? true
            : false;

        private bool IsFromSystemAndGeneric(Type type) =>
            type.AssemblyQualifiedName.StartsWith("System.Collections.Generic");

        private void RegisterType(Type propType, ScourerResult scourerResult) =>
            scourerResult.ResolvedTypes.Add(propType);

        private bool IsRegistered(Type type, ScourerResult scourerResult) =>
            scourerResult.ResolvedTypes.Contains(type);

        protected EventBusAssemblyScourAttribute HasAssemblyScourInstruction() =>
            ExecutionAssembly.GetCustomAttribute<EventBusAssemblyScourAttribute>();

        #endregion Member Functions

    }
}