using System.Security.Cryptography.X509Certificates;
using LolBackdoor.Config;

namespace LolBackdoor.APIs
{
    internal interface ILolApiWithConfig : ILolApi
    {
        LolApiConfig Config { get; set; }
    }
}
