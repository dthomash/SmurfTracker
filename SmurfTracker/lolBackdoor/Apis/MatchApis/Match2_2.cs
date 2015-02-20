using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.MatchApis
{
    internal class Match2_2 : ILolMatchApi, ILolApiWithConfig
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

        public LolMatch GetMatchById(int matchId)
        {
            throw new System.NotImplementedException();
        }
    }
}
