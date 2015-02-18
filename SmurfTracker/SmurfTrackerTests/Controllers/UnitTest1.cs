using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Http.Results;
using LolBackdoor.Data.SummonerData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmurfTracker.Controllers.Apis;

namespace SmurfTrackerTests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var summonerController = new SummonerController();
            var summonerResult = summonerController.GetSummonerByName("dthomash") as OkNegotiatedContentResult<LolSummoner>;
            var summoner = summonerResult.Content;

            Assert.AreEqual("dthomash", summoner.SummonerName);
        }
    }
}
