using Insight.Database;
using Newtonsoft.Json;
using Updater.Common;

namespace Updater.Apis.Dtos
{
    public class SeasonDto : IDto
    {
        [RecordId]
        [JsonProperty("I")]
        public string Id { get; set; }

        [JsonProperty("T")]
        public string Title { get; set; }

        [ParentRecordId]
        [JsonIgnore]
        public string LeagueId { get; set; }

        [JsonConstructor]
        public SeasonDto(string i, string t)
        {
            Id    = i;
            Title = t;
        }

        public SeasonDto(string id, string title, string leagueId) : this(id, title)
        {
            LeagueId = leagueId;
        }
    }
}