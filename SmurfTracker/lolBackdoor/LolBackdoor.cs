using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolBackdoor.Config;

namespace LolBackdoor
{
    public class LolBackdoor
    {
        private const string ServerApiConfigFileName = "ServerAPIConfig.xml";

        private readonly LolBackdoorConfig _config;
        private readonly Dictionary<LolRegion, LolServer> _servers; 

        public LolBackdoor(string configFilePath)
        {
            _config = new LolBackdoorConfig(configFilePath);
            _servers = new Dictionary<LolRegion, LolServer>();
        }

        public LolServer GetServer(LolRegion region)
        {
            LolServer server;
            if (_servers.TryGetValue(region, out server) && server != null)
            {
                return server;
            }
            else
            {
                server = new LolServer(_config.ServerConfigs[region]);
                _servers.Add(region, server);
                return server;
            }
        }

        public LolServer this[LolRegion region]
        {
            get
            {
                return GetServer(region);
            }
        }
    }
}
