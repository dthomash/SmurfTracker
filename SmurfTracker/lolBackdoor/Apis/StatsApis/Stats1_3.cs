using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.StatsApis
{
    internal class Stats1_3 : ILolStatsApi, ILolApiWithConfig
    {
        public LolApiConfig Config { get; set; }
        public LolApi Api
        {
            get { throw new NotImplementedException(); }
        }

        public LolRegion Region
        {
            get { throw new NotImplementedException(); }
        }

        public string Version
        {
            get { throw new NotImplementedException(); }
        }

        public LolRankedStats GetRankedStatsBySummonerId(int summonerId)
        {
            throw new NotImplementedException();
        }

        public LolSummaryStats GetSummaryStatsBySummonerId(int summonerId)
        {
            throw new NotImplementedException();
        }
    }
}
