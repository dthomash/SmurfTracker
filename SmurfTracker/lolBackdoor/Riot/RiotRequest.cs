using System.Net;
using LolBackdoor.Config;

namespace LolBackdoor.Riot
{
    public class RiotRequest
    {
        private HttpWebRequest RequestToRiot { get; set; }
        internal LolApiConfig ApiConfig { get; private set; }

        public RiotRequest(string url, LolApiConfig apiConfig)
        {
            RequestToRiot = WebRequest.CreateHttp(url);
            ApiConfig = apiConfig;
        }

        public RiotResponse GetResponse()
        {
            return new RiotResponse(this);
        }

        internal WebRequest GetWebRequest()
        {
            return RequestToRiot;
        }
    }
}
