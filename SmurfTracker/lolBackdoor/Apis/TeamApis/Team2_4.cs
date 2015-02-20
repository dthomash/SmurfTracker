using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.TeamApis
{
    internal class Team2_4 : ILolTeamApi, ILolApiWithConfig
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

        public Dictionary<int, LolTeam[]> GetTeamsBySummonerIds(int[] summonerIds)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, LolTeam[]> GetTeamsByTeamIds(string[] teamIds)
        {
            throw new NotImplementedException();
        }
    }
}
