using System;
using System.Collections.Generic;
using LolBackdoor.Config;
using LolBackdoor.Data.ServerData;
using LolBackdoor.Data.StaticData;

namespace LolBackdoor.APIs.StaticDataApis
{
    internal class StaticData1_2 : ILolStaticDataApi, ILolApiWithConfig
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

        public List<LolChampion> GetAllChampions()
        {
            throw new NotImplementedException();
        }

        public LolChampion GetChampionById(int championId)
        {
            throw new NotImplementedException();
        }

        public List<LolItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public LolItem GetItemById(int itemId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetLanguages()
        {
            throw new NotImplementedException();
        }

        public List<LolMastery> GetAllMasteries()
        {
            throw new NotImplementedException();
        }

        public LolMastery GetMasteryById(int masteryId)
        {
            throw new NotImplementedException();
        }

        public LolRealm GetRealmInfo()
        {
            throw new NotImplementedException();
        }

        public List<LolRune> GetAllRunes()
        {
            throw new NotImplementedException();
        }

        public LolRune GetRuneById(int runeId)
        {
            throw new NotImplementedException();
        }

        public List<LolSummonerSpell> GetAllSummonerSpells()
        {
            throw new NotImplementedException();
        }

        public LolSummonerSpell GetSummonerSpellById(int summonerSpellId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetVersionNumbers()
        {
            throw new NotImplementedException();
        }
    }
}
