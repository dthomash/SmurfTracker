using System.ComponentModel.DataAnnotations;

namespace LolBackdoor.Data.SummonerData
{
    public class LolSummoner
    {
        [Key]
        public int SummonerId { get; set; }
        public string SummonerName { get; set; }
        public int SummonerIconId { get; set; }
        public long RevisionDate { get; set; }
        public int SummonerLevel { get; set; }
    }
}
