using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using TA.Corel;

namespace TA.Main
{
    class ImportPlayers
    {
        internal static string sPublicKeyB = @"Hn8GBOhaIeRATYcaXKK4Ucy9MKd+UU4Y8FCLZy7EZM1MRXCEKXVcXKFEA/24vYS/yoesg4+";
        public static bool ImportXml(string xml_file, out PlayerInfo[] players) 
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xml_file);
                XmlElement root = doc.DocumentElement;                
                DateTime date = DateTime.Parse(root.Attributes["Date"].Value);

                XmlNodeList games_xml = doc.GetElementsByTagName("GameTypes");                
                XmlNodeList players_xml = doc.GetElementsByTagName("Players");

                List<TypeOfSport> typesOfSport = new List<TypeOfSport>();
                List<PlayerInfo> players_list = new List<PlayerInfo>();

                foreach (XmlNode node in players_xml[0].ChildNodes) 
                {
                    if (node.Name == "Player") 
                    {
                        PlayerInfo player = new PlayerInfo();
                        player.Identifier = new Guid(node.Attributes["Guid"].Value);
                        player.LastName = node.Attributes["LName"].Value;
                        player.FirstName = node.Attributes["FName"].Value;
                        player.PatronymicName = node.Attributes["PName"].Value;
                        player.NickName = node.Attributes["Nick"].Value;
                        player.EMail = node.Attributes["EMail"].Value;
                        player.Phone = node.Attributes["Phone"].Value;
                        player.Country = node.Attributes["Country"].Value;
                        player.City = node.Attributes["City"].Value;
                        players_list.Add(player);
                    }
                }
                players = players_list.ToArray();
                
            }
            catch (Exception) 
            {
                players = null;
                return false;
            }
            return true;
        }
    }
}
