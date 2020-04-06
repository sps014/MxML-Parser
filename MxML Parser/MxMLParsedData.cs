using System.Collections.Generic;

namespace MxML.Parser
{
    public class MxMLParsedData
    {
       public string RazorCode { get; set; }
       public string Path { get; set; }
       public string States { get; set; }
       public string Transitions { get; set; }
       public string RemoteObject { get; set; }
       public ActionScript ActionScript { get; set; } = new ActionScript();
    }
    public class ActionScript
    {
        public string CSImports { get; set; }
        public string ActionCode { get; set; }

    }

}