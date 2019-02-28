using Kros.EventBusDoc.Generator.BusentScour.Document.InternStructure;
using Kros.EventBusDoc.Generator.BusentScour.Interfaces;
using Kros.EventBusDoc.Generator.BusentScour.XmlReader;
using Kros.EventBusDoc.Generator.Helpers;
using Kros.EventBusDoc.Generator.Middleware.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kros.EventBusDoc.Generator.BusentScour.Generators
{
    internal class DeclarativeGenerator : IBusentProvider
    {
        private readonly IScourer _scourer;
        private readonly IXmlDocumentationReader _xmlReader;
        private DocFormat _document;

        public DocFormat Document
        {
            get
            {
                _document = GenerateFormat("natvrdo");
                return _document;
            }
            set { _document = value; }
        }

        public DeclarativeGenerator(IScourer scourer, IXmlDocumentationReader xmlReader)
        {
            _scourer = scourer;
            _xmlReader = xmlReader;
        }

        public DocFormat GenerateFormat(string apiName)
        {
            var format = new DocFormat
            {
                MiddleWareVersion = apiName
            };

            _scourer.Scour();
            _xmlReader.Load(_scourer.ExecutionAssembly.GetDocumentPath());

            format.Service = GenerateService();
            format.Definitions = GenerateAllDefinitions().ToList();
            format.Types = GenerateAllTypes().ToList();

            return format;
        }

        private Service GenerateService() =>
            new Service
            {
                Events = from type in _scourer.Events select type.Name,
                Commands = from type in _scourer.Commands select type.Name,
                Consumes = from type in _scourer.Consumes select type.Name,

                Version = "v0",
                Name = "Service",
                Description = "No definition"
            };

        private DescriptiveObject GetDefinition(Type item, MessageType eMessageType = MessageType.None)
        {
            var descObj = InitDescriptiveObject(item, eMessageType);

            foreach (var prop in item.GetProperties())
            {
                descObj.Properties = descObj.Properties.Append(
                        new Property()
                        {
                            Description = _xmlReader.GetSummary(item, prop),
                            Name = prop.Name,
                            IsPrimitive = prop.PropertyType.IsPrimitive,
                            Type = prop.PropertyType.GetName(),
                            FullName = prop.PropertyType.GetFullName()
                        }
                    );
            }

            return descObj;
        }

        private DescriptiveObject InitDescriptiveObject(Type item, MessageType eMessageType)
        {
            DescriptiveObject messDef;

            if (eMessageType != MessageType.None)
            {
                messDef = new MessageDefinition()
                {
                    Name = item.GetName(),
                    FullName = item.GetFullName(),
                    MessageType = eMessageType,
                    Description = _xmlReader.GetSummary(item)
                };
            }
            else
            {
                messDef = new DescriptiveType()
                {
                    Name = item.GetName(),
                    FullName = item.GetFullName(),
                    Description = _xmlReader.GetSummary(item)
                };
            }

            return messDef;
        }

        private IEnumerable<MessageDefinition> GenerateAllDefinitions()
        {
            var definitionList = new List<MessageDefinition>();

            foreach (var item in _scourer.Events)
            {
                definitionList.Add((MessageDefinition)GetDefinition(item, MessageType.Event));
            }

            foreach (var item in _scourer.Commands)
            {
                definitionList.Add((MessageDefinition)GetDefinition(item, MessageType.Command));
            }

            return definitionList;
        }

        private IEnumerable<DescriptiveType> GenerateAllTypes()
        {
            var typeList = new List<DescriptiveType>();

            foreach (var item in _scourer.ResolvedTypes)
            {
                typeList.Add((DescriptiveType)GetDefinition(item));
            }

            return typeList;
        }

        public string Serialize(JsonSerializerSettings serializerSettings = null)
        {
            var structure = GenerateFormat("natvrdo");

            var set = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            set.Converters.Add(new StringEnumConverter());

            return JsonConvert.SerializeObject(structure,
                serializerSettings ?? new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}