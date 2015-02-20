using System.Collections.Generic;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.LeagueApis
{
    public interface ILolLeagueApi : ILolApi
    {
        LolLeague GetChallengerLeague();
        Dictionary<int, List<LolLeague>> GetLeaguesBySummoners(List<int> summonerIds);
        Dictionary<int, List<LolLeagueEntry>> GetLeagueEntriesBySummoners(List<int> summonerIds);
        Dictionary<string, List<LolLeague>> GetLeaguesByTeams(List<string> teamIds);
        Dictionary<string, List<LolLeagueEntry>> GetLeagueEntriesByTeams(List<string> teamIds);
    }
}
