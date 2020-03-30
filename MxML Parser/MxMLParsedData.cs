using System.Collections.Generic;

namespace MxML.Parser
{
    public class MxMLParsedData
    {
        public string Version { get; set; }
        public string Encoding { get; set; }
        public ChildNode Child { get; set; }
        public string Path { get; set; }
    }
    public class ChildNode
    {
        public ChildNode[] Children { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public string Name { get; set; }
    }
}