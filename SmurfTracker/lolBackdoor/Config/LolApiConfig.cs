using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LolBackdoor.APIs;

namespace LolBackdoor.Config
{
    public enum LolApi
    {
        Champion,
        Game,
        League,
        Match,
        MatchHistory,
        StaticData,
        Stats,
        Status,
        Summoner,
        Team,
        Error
    }

    public class LolApiConfig
    {
        public LolApi Api
        {
            get { return _api; }
        }

        public LolRegion Region { get {return _region;} }
        public string Version
        {
            get { return _version; }
        }

        public string Endpoint
        {
            get { return _endpoint; }
        }

        public string ApiKey
        {
            get { return _apikey; }
        }

        private readonly LolApi _api;
        private readonly LolRegion _region;
        private readonly string _version;
        private readonly string _endpoint;
        private readonly string _apikey;

        public LolApiConfig(XmlElement apiElement, LolRegion region, string endpoint, string apikey)
        {
            if (!Enum.TryParse(apiElement.GetAttribute("name"), out _api))
            {
                throw new ArgumentException("The Api element did not have a valid name (" + apiElement.GetAttribute("name") + ")");
            }
            var versions = apiElement.GetElementsByTagName("version");
            if (versions.Count != 1)
            {
                throw new ArgumentException("The Api element did not have a single version child element.");
            }
            var version = versions[0];
            if (version == null || !System.Text.RegularExpressions.Regex.IsMatch(version.InnerText, @"\d\.[\d]*"))
            {
                throw new ArgumentException("The api element's version sub-element did not contain a valid version number");
            }
            _version = version.InnerText;
            _endpoint = endpoint;
            _region = region;
            _apikey = apikey;
        }
    }
}
