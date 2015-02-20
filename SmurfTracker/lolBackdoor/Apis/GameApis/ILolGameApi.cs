using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.GameApis
{
    public interface ILolGameApi : ILolApi
    {
        List<LolMatch> GetRecentMatches(int summonerId);
    }
}
