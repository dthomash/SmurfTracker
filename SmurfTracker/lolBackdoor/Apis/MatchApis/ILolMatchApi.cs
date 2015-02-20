using LolBackdoor.Data.SummonerData;
namespace LolBackdoor.APIs.MatchApis
{
    public interface ILolMatchApi : ILolApi
    {
        LolMatch GetMatchById(int matchId);
    }
}
