using System.Collections.Generic;
using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.MatchHistoryApis
{
    internal class MatchHistory2_2 : ILolMatchHistoryApi, ILolApiWithConfig
    {
        public LolApiConfig Config { get; set; }
        public LolApi Api
        {
            get { throw new System.NotImplementedException(); }
        }

        public LolRegion Region
        {
            get { throw new System.NotImplementedException(); }
        }

        public string Version
        {
            get { throw new System.NotImplementedException(); }
        }

        public List<LolMatch> GetMatchHistoryBySummonerId(int summonerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
