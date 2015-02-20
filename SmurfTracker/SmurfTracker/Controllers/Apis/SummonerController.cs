using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LolBackdoor.APIs.SummonerApis;
using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;
using SmurfTracker.ApiControllers;
using LolBackdoor = LolBackdoor.LolBackdoor;

namespace SmurfTracker.Controllers.Apis
{
    [RoutePrefix("api/summoner")]
    public class SummonerController : ApiController
    {
        public static readonly global::LolBackdoor.LolBackdoor lol = new global::LolBackdoor.LolBackdoor("LolBackdoorConfig.xml");
        private ISummonerApiController summonerApiController = new SummonerApiController();

        [ResponseType(typeof(LolSummoner))]
        public IHttpActionResult GetSummonerByName(string summonerName)
        {
            return Ok(summonerApiController.GetSummonerBySummonerName(summonerName)[summonerName]);
        }
    }
}
