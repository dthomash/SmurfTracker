using System.Collections.Generic;
using LolBackdoor.Data.ServerData;
using LolBackdoor.Data.StaticData;

namespace LolBackdoor.APIs.StaticDataApis
{
    public interface ILolStaticDataApi : ILolApi
    {
        List<LolChampion> GetAllChampions();
        LolChampion GetChampionById(int championId);
        List<LolItem> GetAllItems();
        LolItem GetItemById(int itemId);
        List<string> GetLanguages();
        List<LolMastery> GetAllMasteries();
        LolMastery GetMasteryById(int masteryId);
        LolRealm GetRealmInfo();
        List<LolRune> GetAllRunes();
        LolRune GetRuneById(int runeId);
        List<LolSummonerSpell> GetAllSummonerSpells();
        LolSummonerSpell GetSummonerSpellById(int summonerSpellId);
        List<string> GetVersionNumbers();
    }
}
