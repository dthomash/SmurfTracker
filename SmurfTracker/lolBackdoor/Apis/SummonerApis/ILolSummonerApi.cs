using System.Collections.Generic;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.SummonerApis
{
    public interface ILolSummonerApi : ILolApi
    {
        Dictionary<string, LolSummoner> GetSummonersBySummonerNames(string[] names);
        Dictionary<int, LolSummoner> GetSummonersBySummonerIds(int[] summonerIds);
        Dictionary<int, LolMasteryPage[]> GetMasteryPagesBySummonerIds(int[] summonerIds);
        Dictionary<int, string> GetSummonerNamesBySummonerIds(int[] summonerIds);
        Dictionary<int, LolRunePage[]> GetRunePagesBySummonerIds(int[] summonerIds);
    }
}
