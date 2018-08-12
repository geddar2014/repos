using Newtonsoft.Json;

namespace ConsUpdater.Entities
{
	public class League
	{
		[JsonProperty("I")]
		public string Id { get; set; }
		[JsonIgnore]
		public string CountryId { get; set; }
		[JsonProperty("T")]
		public string Title { get; set; }
	}
}