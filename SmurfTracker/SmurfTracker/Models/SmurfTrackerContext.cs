using System.Data.Entity;
using LolBackdoor.Data.SummonerData;

namespace SmurfTracker.Models
{
    public class SmurfTrackerContext : DbContext
    {
        public DbSet<LolSummoner> Summoners { get; set; }
    }
}