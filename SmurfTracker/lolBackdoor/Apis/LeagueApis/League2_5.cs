using System;
using System.Collections.Generic;
using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.LeagueApis
{
    internal class League2_5 : ILolLeagueApi, ILolApiWithConfig
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

        public LolLeague GetChallengerLeague()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<LolLeague>> GetLeaguesBySummoners(List<int> summonerIds)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<LolLeagueEntry>> GetLeagueEntriesBySummoners(List<int> summonerIds)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<LolLeague>> GetLeaguesByTeams(List<string> teamIds)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<LolLeagueEntry>> GetLeagueEntriesByTeams(List<string> teamIds)
        {
            throw new NotImplementedException();
        }
    }
}
