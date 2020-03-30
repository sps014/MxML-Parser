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

            result.Path = path;

            return result;
        }


        private static MxMLParsedData ParseChildern(string path)
        {
            XmlDocument document = new XmlDocument();
            JObject data = null;
            try
            {
                document.Load(path);

                string json = JsonConvert.SerializeXmlNode(document);
                data = JObject.Parse(json);
            }
            catch(Exception e)
            {
                HelperUtility.LogError(e.Message);
            }
            return JsonDataToMxMLParsed(data);
        }
        private static MxMLParsedData JsonDataToMxMLParsed(JObject data)
        {
            MxMLParsedData pObject = new MxMLParsedData();

            var headResult=ParseHeader(data, ref pObject);
            if (!headResult)
                return null;

            var childernResult = ParseChildern(data,ref pObject);
            if (!childernResult)
                return null;

            return pObject;
        }
        private static bool ParseHeader(JObject data,ref MxMLParsedData pObject)
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
        private static bool ParseChildern(JObject data,ref MxMLParsedData pObject)
        {
            foreach(var d in data)
            {
                if (d.Key == "?xml")
                    continue;

                pObject.Child=SolveChildNode((JObject)d.Value);
                if (pObject.Child != null)
                    pObject.Child.Name = d.Key;
                else
                    HelperUtility.LogError("Can't parse the Root Element");

                break;
            }
            return true;
        }
        private static ChildNode SolveChildNode(JObject data)
        {
            ChildNode node = new ChildNode();
            foreach(var n in data)
            {
                Console.WriteLine(n.Key);
            }
            return node;
        }
    }
}
