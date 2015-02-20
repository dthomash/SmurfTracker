using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace LolBackdoor.Config
{
    public enum LolRegion
    {
        BR,
        EUW,
        EUNE,
        KR,
        LAN,
        LAS,
        NA,
        OCE,
        RU,
        TR,
        Error
    }
    public class LolServerConfig
    {
        public Dictionary<LolApi, LolApiConfig> ApiConfigs
        {
            get { return _apiConfigs; }
        }

        public LolRegion Region
        {
            get { return _region; }
        }

        public string Endpoint
        {
            get { return _endpoint; }
        }

        private readonly Dictionary<LolApi, LolApiConfig> _apiConfigs;
        private readonly LolRegion _region;
        private readonly string _endpoint;

        public LolServerConfig(XmlElement serverElement, string apikey)
        {
            var apiElements = ServerApiConfigHelper.GetServerApiElements(serverElement);
            if (!Enum.TryParse(serverElement.GetAttribute("region"), out _region))
            {
                throw new ArgumentException("The server element's region attribute did not evaluate to a region.");
            }

            var endpoints = serverElement.GetElementsByTagName("endpoint");
            if (endpoints.Count != 1)
            {
                throw new ArgumentException("The Server element (" + _region + ") must have a single endpoint child element.");
            }
            var endpoint = endpoints[0];
            if (endpoint == null || !System.Text.RegularExpressions.Regex.IsMatch(endpoint.InnerText, @"\w*\.api\.pvp\.net")) // todo fix regex
            {
                throw new ArgumentException("The server element's enpoint sub-element did not contain a valid endpoint");
            }
            _endpoint = endpoint.InnerText;

            LolApi api;
            _apiConfigs = apiElements.ToDictionary(apiElement => Enum.TryParse(apiElement.GetAttribute("name"), out api) ? api : LolApi.Error, apiElement => new LolApiConfig(apiElement, _region, _endpoint, apikey));
        }
    }
}
