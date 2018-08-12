using System.Collections.Generic;
using Insight.Database;
using Newtonsoft.Json;
using Updater.Common;

namespace Updater.Apis.Dtos
{
    public class CountryDto : BaseDtoWithTitle, IDtoWithTitle
    {
        [RecordId]
        [JsonProperty("I")]
        public override string Id { get; set; }

        [JsonProperty("N")]
        public override string Title { get; set; }

        [JsonProperty("C")]
        public int XBetId { get; set; }

        [ChildRecords]
        [JsonProperty("T")]
        public IList<LeagueDto> Leagues { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Title}";
        }
    }
}