using System.Collections.Generic;

namespace Kros.EventBusDoc.Generator.BusentScour.Document.InternStructure
{
    public class Service : Descpritive
    {
        public IEnumerable<string> Events { get; set; }
        public IEnumerable<string> Commands { get; set; }
        public IEnumerable<string> Consumes { get; set; }
        public string Version { get; set; }

        public Service()
        {
            Events = new List<string>();
            Commands = new List<string>();
            Consumes = new List<string>();
        }
    }
}