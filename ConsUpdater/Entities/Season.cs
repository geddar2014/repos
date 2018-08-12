using Newtonsoft.Json;

namespace ConsUpdater.Entities
{
	public class Season
	{
		[JsonIgnore]
		public string LeagueId { get; set; }

		[JsonProperty("I")]
		public string Id { get; set; }

		[JsonProperty("T")]
		public string Title { get; set; }
	}
}