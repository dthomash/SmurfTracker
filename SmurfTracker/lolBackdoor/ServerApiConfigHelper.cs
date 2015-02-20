using System.Collections.Generic;
using System.Linq;
using System.Xml;
using LolBackdoor.Config;

namespace LolBackdoor
{
    internal static class ServerApiConfigHelper
    {
        private const string AttrNameName = "name";

        public static IEnumerable<XmlElement> GetServerApiElements(XmlElement serverElement)
        {
            return serverElement.ChildNodes
                .OfType<XmlElement>()
                .First(element => element.Name == "apis")
                .ChildNodes
                .OfType<XmlElement>();
        }

        public static IEnumerable<XmlElement> GetServerElements(XmlElement lolElement)
        {
            return GetElementsByElementName(lolElement, "server");
        }

        public static XmlElement GetLeagueOfLegendsElement(XmlDocument riotServerDoc)
        {
            return GetElementsByNameAndElementName(riotServerDoc.DocumentElement, "game", "LeagueOfLegends")
                .First();
        }

        private static IEnumerable<XmlElement> GetElementsByNameAndElementName(XmlElement node, string elementName, string name)
        {
            return GetElementsByElementNameAndAttributeValue(node, elementName, AttrNameName, name);
        }

        private static IEnumerable<XmlElement> GetElementsByElementNameAndAttributeValue(XmlElement node, string elementName, string attrName,
            string attrValue)
        {
            return node.GetElementsByTagName(elementName)
                .OfType<XmlElement>()
                .Where(x => x.HasAttribute(attrName) && x.GetAttribute(attrName) == attrValue);
        }

        private static IEnumerable<XmlElement> GetElementsByElementName(XmlElement node, string elementName)
        {
            return node.GetElementsByTagName(elementName)
                .OfType<XmlElement>();
        }
    }
}
