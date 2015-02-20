using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.GameApis
{
    internal class Game1_3 : ILolGameApi, ILolApiWithConfig
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

        public List<LolMatch> GetRecentMatches(int summonerId)
        {
            throw new NotImplementedException();
        }
    }
}
