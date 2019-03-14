using Kros.EventBusDoc.Generator.BusentScour.Document;
using Kros.EventBusDoc.Generator.BusentScour.Scourers;
using Kros.EventBusDoc.Generator.BusentScour.XmlReader;
using Kros.EventBusDoc.Generator.Helpers;
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
        private ServiceSettings Settings { get; set; } = new ServiceSettings();
        public DocFormat Document
        {
            get
            {
                _document = GenerateFormat();
                return _document;
            }
            set { _document = value; }
        }

        public DeclarativeGenerator(IScourer scourer, IXmlDocumentationReader xmlReader)
        {
            _scourer = scourer;
            _xmlReader = xmlReader;
        }

        public DocFormat GenerateFormat()
        {
            var format = new DocFormat
            {
                MiddleWareVersion = "v1.0"
            };

            var _scourerResult = _scourer.Scour();
            _xmlReader.Load(_scourer.ExecutionAssembly.GetDocumentPath());

            format.Service = GenerateService(_scourerResult);
            format.Definitions = GenerateAllDefinitions(_scourerResult).ToList();
            format.Types = GenerateAllTypes(_scourerResult).ToList();

            return format;
        }

        private Service GenerateService(ScourerResult scourerResult) =>
            new Service
            {
                Events = from type in scourerResult.Events select type.Name,
                Commands = from type in scourerResult.Commands select type.Name,
                Consumes = from type in scourerResult.Consumes select type.Name,

                Version = Settings.Version,
                Name = Settings.Name,
                Description = Settings.Description
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

        private IEnumerable<MessageDefinition> GenerateAllDefinitions(ScourerResult scourerResult)
        {
            var definitionList = new List<MessageDefinition>();

            foreach (var item in scourerResult.Events)
            {
                definitionList.Add((MessageDefinition)GetDefinition(item, MessageType.Event));
            }

            foreach (var item in scourerResult.Commands)
            {
                definitionList.Add((MessageDefinition)GetDefinition(item, MessageType.Command));
            }

            return definitionList;
        }

        private IEnumerable<DescriptiveType> GenerateAllTypes(ScourerResult scourerResult)
        {
            var typeList = new List<DescriptiveType>();

            foreach (var item in scourerResult.ResolvedTypes)
            {
                typeList.Add((DescriptiveType)GetDefinition(item));
            }

            return typeList;
        }

        public string Serialize(ServiceSettings serviceSettings, JsonSerializerSettings serializerSettings = null)
        {
            Settings = serviceSettings;
            var structure = GenerateFormat();

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