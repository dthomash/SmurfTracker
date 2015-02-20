using System.Collections.Generic;
using LolBackdoor.Data.ServerData;

namespace LolBackdoor.APIs.StatusApis
{
    public interface ILolStatusApi : ILolApi
    {
        List<LolShard> GetAllShards();
        LolShard GetThisServersShard();
    }
}
