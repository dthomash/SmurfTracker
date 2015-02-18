using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolBackdoor.Data.SummonerData;

namespace SmurfTracker.ApiControllers
{
    interface ISummonerApiController
    {
        Dictionary<string, LolSummoner> GetSummonerBySummonerName(string summonerNames);
    }
}
