using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LolBackdoor.Config
{
    public class LolBackdoorConfig
    {
        public Dictionary<LolRegion, LolServerConfig> ServerConfigs
        {
            get { return _serverConfigs; }
        }

        private readonly Dictionary<LolRegion, LolServerConfig> _serverConfigs;

        public LolBackdoorConfig(string configFileName)
        {
            XmlDocument serverConfig = new XmlDocument();
            serverConfig.Load(configFileName);
            var lolElement = ServerApiConfigHelper.GetLeagueOfLegendsElement(serverConfig);
            var apikey =
                lolElement.ChildNodes.OfType<XmlElement>().First(ele => ele.Name == "api-key").InnerText;
            LolRegion region;
            _serverConfigs = ServerApiConfigHelper.GetServerElements(lolElement)
                .ToDictionary(server => LolRegion.TryParse(server.GetAttribute("region"), out region)?region:LolRegion.Error, server => new LolServerConfig(server, apikey));
        }
    }
}
