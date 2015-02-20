using System.Collections.Generic;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.MatchHistoryApis
{
    public interface ILolMatchHistoryApi : ILolApi
    {
        List<LolMatch> GetMatchHistoryBySummonerId(int summonerId);
    }
}
