﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Helpers;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace MxML.Parser
{
    public class Parser
    {
        public static void Main(string[] args)
        {
            ParseData(@"C:\Users\shive\Desktop\loginscreen\flex");

        }
        public static MxMLParsedData[] ParseData(string path)
        {
            HelperUtility.LogInitiation($"Started Parsing files of Path:{path}");
            var parseSuccessStatus = true;

            List<MxMLParsedData> parseResult = new List<MxMLParsedData>();
            var files=HelperUtility.GetAllFilesOfExtension(path, ".mxml");
            foreach (string file in files)
            {
                HelperUtility.LogStatus($"started parsing {file}");
                var pResult = ParseSingleMxML(file);
                if (pResult != null)
                    parseResult.Add(pResult);
                else
                    parseSuccessStatus = false;
            }

            if (parseSuccessStatus)
                HelperUtility.LogSuccess("Successfully parsed files");
            else
                HelperUtility.LogError("Failed parsing files");


            return parseResult.ToArray();
        }
        private static MxMLParsedData ParseSingleMxML(string path)
        {
            MxMLParsedData result = ParseChildern(path);

            //For the first line get the Version
            return result;
        }


        private static MxMLParsedData ParseChildern(string path)
        {
            XmlDocument document = new XmlDocument();
            document.Load(path);

            string json=JsonConvert.SerializeXmlNode(document);
            var data = JObject.Parse(json);
            return JsonDataToMxMLParsed(data);
        }
        private static MxMLParsedData JsonDataToMxMLParsed(JObject data)
        {
            MxMLParsedData pObject = new MxMLParsedData();

            try
            {
                var version = ((JObject)data["?xml"])["@version"].Value<string>();
                var encoding = ((JObject)data["?xml"])["@encoding"].Value<string>();
                if (version == null || encoding == null)
                    throw new Exception();

                pObject.Encoding = encoding;
                pObject.Version = version;

            }
            catch(Exception)
            {
                HelperUtility.LogError("Can't parse version and encoding ");
                return null;
            }
            foreach(var item in data)
            {
                var k = item.Key;
                var v = ((JObject)item.Value)["@version"];
                Console.WriteLine(v["version"]);
                break;
            }

            return null;
        }
        private bool ParseHeader(JObject data,ref MxMLParsedData pObject)
        {
            try
            {
                var version = ((JObject)data["?xml"])["@version"].Value<string>();
                var encoding = ((JObject)data["?xml"])["@encoding"].Value<string>();
                if (version == null || encoding == null)
                    throw new Exception();

                pObject.Encoding = encoding;
                pObject.Version = version;
                return true;
            }
            catch (Exception)
            {
                HelperUtility.LogError("Can't parse version and encoding ");
                return false;
            }
        }
    }
}

//<\w*\s\w*\W*(.*)>

// <div id='container'>
// <div class='nested'>
// <a href='some url' class='link'>
// </a>
// </div>
// </div>

// #some scripts ....

// <div id='container'>
// <div class='nested'>
// <a href='some url' class='link'>
// </a>
// </div>
// </div>


//    <h1>
// <a>content inside</a>
// </h1>

//<(\w+)>\s*<(\w+)>\s*(.*)\s*<\/\2>\s*<\/\1>