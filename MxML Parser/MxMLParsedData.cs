using System.Collections.Generic;

namespace MxML.Parser
{
    public class MxMLParsedData
    {
        public string Version;
        public string Encoding;
        public ChildNode Child;
    }
    public class ChildNode
    {
        public ChildNode[] Children;
        public Dictionary<string, string> Parameters;
    }
}