using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.StatsApis
{
    public interface ILolStatsApi : ILolApi
    {
        LolRankedStats GetRankedStatsBySummonerId(int summonerId);
        LolSummaryStats GetSummaryStatsBySummonerId(int summonerId);
    }
}
