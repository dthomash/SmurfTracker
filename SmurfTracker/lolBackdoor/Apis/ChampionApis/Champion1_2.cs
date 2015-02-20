using System;
using System.Collections.Generic;
using LolBackdoor.Config;
using LolBackdoor.Data.StaticData;

namespace LolBackdoor.APIs.ChampionApis
{
    internal class Champion1_2 : ILolChampionApi, ILolApiWithConfig
    {
        public LolApiConfig Config { get; set; }
        public LolApi Api { get { return Config.Api; } }
        public LolRegion Region { get { return  Config.Region; } }
        public string Version { get { return Config.Version; } }

        public Dictionary<int, LolChampion> GetAllChampions()
        {
            throw new NotImplementedException();
        }

        public LolChampion GetChampion(int id)
        {
            throw new NotImplementedException();
        }
    }
}
