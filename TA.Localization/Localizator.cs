using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Xml;
using System.IO;


namespace Localizator
{
    public class Dictionary
    {
        private Dictionary<string, string> FDict = new Dictionary<string, string>();
        public Dictionary(string defLang) 
        {
            LoadFromXml(defLang);
        }
        public void LoadFromXml(string defLang) 
        {
            string lang = "RU";
            if(defLang == null)
                defLang = "";
            string word = "";
            string word_value = "";
            FDict.Clear();
            XmlTextReader reader = GetDictionaryXmlReader();
                
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:    // Узел является элементом.                        
                        if (reader.Name == "DICTIONARY" && defLang == "")
                        {
                            lang = reader.GetAttribute("current");
                        }
                        if (reader.Name == "WORD")
                        {
                            word = reader.GetAttribute("value");
                        }
                        if (reader.Name == defLang)
                        {
                            word_value = reader.GetAttribute("value");
                            FDict.Add(word, word_value);
                        }
                        break;
                }
            }
        }

        private static XmlTextReader GetDictionaryXmlReader()
        {
            Stream res_stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Localizator.dictionary.xml");
            if (res_stream != null)
                return new XmlTextReader(res_stream);
            else
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "dictionary.xml");
                return new XmlTextReader(path);
            }
        }
        public string ReadString(string key) 
        {
            
            string value = "";
            if (FDict.TryGetValue(key, out value))
            {
                value = value.Replace(@"\n", Environment.NewLine);
                return value;
            }
            else
            {
                throw new Exception("Word '" + key + "' is not found in dictionary");
                //return "";
            } 
        }

        private static Dictionary LocalDict = null;

        public static Language[] GetLangauges() 
        {
            List<Language> list = new List<Language>();
            XmlTextReader reader = GetDictionaryXmlReader();
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "LANGUAGE")
                        {
                            Language lang = new Language();
                            lang.Id = reader.GetAttribute("id");
                            lang.Description = reader.GetAttribute("description");
                            list.Add(lang);
                        }
                        break;
                }
            }
            return list.ToArray();
        }
        public static void CreateDictionary(string lang) 
        {
            LocalDict = new Dictionary(lang);
        }
        public static string GetString(string strName)
        {
            if (LocalDict != null)
                return LocalDict.ReadString(strName);
            else return strName;
        }
        public static string GetString(string strName, string postString)
        {
            return GetString(strName) + postString;
        }
        public static string GetString(string preString, string strName, string postString)
        {
            return preString + GetString(strName) + postString;
        }

    }
}
