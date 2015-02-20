using System;
using System.Collections.Generic;
using LolBackdoor.Config;
using LolBackdoor.Data.ServerData;

namespace LolBackdoor.APIs.StatusApis
{
    internal class Status1_0 : ILolStatusApi, ILolApiWithConfig
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

        public List<LolShard> GetAllShards()
        {
            throw new NotImplementedException();
        }

        public LolShard GetThisServersShard()
        {
            throw new NotImplementedException();
        }
    }
}
