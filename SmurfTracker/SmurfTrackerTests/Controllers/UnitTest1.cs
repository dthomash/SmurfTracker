using System.Web.Http.Results;
using LolBackdoor.Data.SummonerData;
using SmurfTracker.Controllers.Apis;
using NUnit.Framework;

namespace SmurfTrackerTests.Controllers
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var summonerController = new SummonerController();
            var summonerResult = summonerController.GetSummonerByName("dthomash") as OkNegotiatedContentResult<LolSummoner>;
            var summoner = summonerResult.Content;

            Assert.AreEqual("dthomash", summoner.SummonerName);
        }
    }
}
