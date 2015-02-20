using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LolBackdoor.APIs.ChampionApis;
using LolBackdoor.Config;

namespace LolBackdoor.APIs
{
    internal static class LolApiReflectionHelper
    {
        private static readonly Dictionary<LolApi, string> ApiBaseClassNames = new Dictionary<LolApi, string>()
        {
            {LolApi.Champion, "ChampionApis.Champion"},
            {LolApi.Game, "GameApis.Game"},
            {LolApi.League, "LeagueApis.League"},
            {LolApi.Match, "MatchApis.Match"},
            {LolApi.MatchHistory, "MatchHistoryApis.MatchHistory"},
            {LolApi.StaticData, "StaticDataApis.StaticData"},
            {LolApi.Stats, "StatsApis.Stats"},
            {LolApi.Status, "StatusApis.Status"},
            {LolApi.Summoner, "SummonerApis.Summoner"},
            {LolApi.Team, "TeamApis.Team"}
        };

        private const string BaseClassName = "LolBackdoor.APIs.";

        internal static ILolApi GetLolApi(LolApiConfig config)
        {
            var api = GetLolApi(BaseClassName + ApiBaseClassNames[config.Api] + SanitizeVersionNumber(config.Version));
            api.Config = config;
            return api;
        }

        private static string SanitizeVersionNumber(string versionNumber)
        {
            return versionNumber.Replace(".", "_");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiFullyQualifiedClassName"></param>
        /// <returns>ILolApi objected based upon the api indicated in the fully qualified class name.  If null
        /// there was an error constructing the object.</returns>
        private static ILolApiWithConfig GetLolApi(string apiFullyQualifiedClassName)
        {
            var assemblyName = typeof (Champion1_2).AssemblyQualifiedName.ToString();
            var apiType = Type.GetType(apiFullyQualifiedClassName + ", lolBackdoor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            if (apiType == null)
            {
                throw new ArgumentException("Provided fully qualified class name could not be evalutated to a Type.");
            }

            var api =
                apiType.GetConstructors().First(ctr => !ctr.GetParameters().Any()).Invoke(new object[] { }) as ILolApiWithConfig;

            return api;
        }
    }
}
