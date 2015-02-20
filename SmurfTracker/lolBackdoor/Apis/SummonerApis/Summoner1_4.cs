using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;
using LolBackdoor.Riot;
using Newtonsoft.Json.Linq;

namespace LolBackdoor.APIs.SummonerApis
{
    public class Summoner1_4 : ILolSummonerApi, ILolApiWithConfig
    {

        public LolApiConfig Config { get; set; }
        public LolApi Api { get { return Config.Api; } }
        public LolRegion Region { get { return Config.Region; } }
        public string Version { get { return Config.Version; } }

        private string ApiBaseUrl
        {
            get { return "/api/lol/" + Config.Region.ToString() + "/v1.4/summoner/"; }
        }

        public Dictionary<string, LolSummoner> GetSummonersBySummonerNames(string[] names)
        {
            var urlSb = new StringBuilder();
            urlSb.Append("by-name/");
            foreach (var name in names)
            {
                urlSb.Append(name);
                urlSb.Append(",");
            }
            urlSb.Remove(urlSb.Length - 1, 1);

            var url = ConstructUrl(urlSb.ToString());

            var request = new RiotRequest(url, Config);
            var response = request.GetResponse();
            var responseObject = response.Response;

            var retVal = new Dictionary<string, LolSummoner>();

            foreach (var name in names)
            {
                var summonerJObject = responseObject[name];

                LolSummoner newSummoner = ExtractSummoner(summonerJObject);
                
                retVal.Add(name, newSummoner);
            }

            return retVal;
        }

        public Dictionary<int, LolSummoner> GetSummonersBySummonerIds(int[] summonerIds)
        {
            var urlSb = new StringBuilder();
            foreach (var summonerId in summonerIds)
            {
                urlSb.Append(summonerId);
                urlSb.Append(",");
            }
            urlSb.Remove(urlSb.Length - 1, 1);
            var url = ConstructUrl(urlSb.ToString());
            var request = new RiotRequest(url, Config);
            var response = request.GetResponse();
            var responseObject = response.Response;

            var retVal = new Dictionary<int, LolSummoner>();

            foreach (var summonerId in summonerIds)
            {
                var summonerJObject = responseObject[summonerId.ToString()];

                LolSummoner newSummoner = ExtractSummoner(summonerJObject);

                retVal.Add(summonerId, newSummoner);
            }

            return retVal;
        }

        public Dictionary<int, LolMasteryPage[]> GetMasteryPagesBySummonerIds(int[] summonerIds)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> GetSummonerNamesBySummonerIds(int[] summonerIds)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, LolRunePage[]> GetRunePagesBySummonerIds(int[] summonerIds)
        {
            throw new NotImplementedException();
        }

        private string ConstructUrl(string urlEnding)
        {
            var urlSb = new StringBuilder();
            urlSb.Append("https://");
            urlSb.Append(Config.Endpoint);
            urlSb.Append(ApiBaseUrl);
            urlSb.Append(urlEnding);
            urlSb.Append("?api_key=");
            urlSb.Append(Config.ApiKey);
            return urlSb.ToString();
        }

        private LolSummoner ExtractSummoner(JToken summonerJObject)
        {
            if (summonerJObject == null)
            {
                return null;
            }
            return new LolSummoner
            {
                SummonerId = summonerJObject.Value<int>("id"),
                SummonerName = summonerJObject.Value<string>("name"),
                SummonerIconId = summonerJObject.Value<int>("profileIconId"),
                RevisionDate = summonerJObject.Value<long>("revisionDate"),
                SummonerLevel = summonerJObject.Value<int>("summonerLevel")
            };
        }
    }
}
