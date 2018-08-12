using Insight.Database;
using Newtonsoft.Json;
using Updater.Common;

namespace Updater.Apis.Dtos
{
    public class LeagueDto : IDto
    {
        [RecordId]
        [JsonProperty("I")]
        public string Id { get; set; }

        [JsonProperty("T")]
        public string Title { get; set; }

        [ParentRecordId]
        [JsonIgnore]
        public string CountryId { get; set; }

        [JsonConstructor]
        public LeagueDto(string i, string t)
        {
            Id    = i;
            Title = t;
        }

        public LeagueDto(string id, string title, string countryId) : this(id, title)
        {
            CountryId = countryId;
        }
    }
}