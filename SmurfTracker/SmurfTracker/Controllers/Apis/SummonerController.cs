using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;
using LolBackdoor = LolBackdoor.LolBackdoor;

namespace SmurfTracker.Controllers.Apis
{
    [RoutePrefix("api/summoner")]
    public class SummonerController : ApiController
    {
        readonly global::LolBackdoor.LolBackdoor lol = new global::LolBackdoor.LolBackdoor("D:\\MyDocs\\League\\SmurfTracker\\SmurfTracker\\SmurfTracker\\LolBackdoorConfig.xml");

        [ResponseType(typeof(LolSummoner))]
        public IHttpActionResult GetSummonerByName(string summonerName)
        {
            return Ok(lol[LolRegion.NA].SummonerApi.GetSummonersBySummonerNames(new string[] {summonerName}));
        }
    }
}
