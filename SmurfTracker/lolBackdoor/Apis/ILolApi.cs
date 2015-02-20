using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolBackdoor.Config;

namespace LolBackdoor.APIs
{
    public interface ILolApi
    {
        LolApi Api { get; }
        LolRegion Region { get; }
        string Version { get; }
    }
}
