using System.Collections.Generic;
using LolBackdoor.Data.SummonerData;

namespace LolBackdoor.APIs.TeamApis
{
    public interface ILolTeamApi : ILolApi
    {
        Dictionary<int, LolTeam[]> GetTeamsBySummonerIds(int[] summonerIds);
        Dictionary<int, LolTeam[]> GetTeamsByTeamIds(string[] teamIds);
    }
}
