using Newtonsoft.Json;

namespace ConsUpdater.Entities
{
	public class League
	{
		[JsonIgnore]
		public string CountryId { get; set; }

		[JsonProperty("I")]
		public string Id { get; set; }

		[JsonProperty("T")]
		public string Title { get; set; }
	}
}