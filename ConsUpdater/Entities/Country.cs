using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsUpdater.Entities
{
	public class Country
	{
		[JsonProperty("C")]
		public int XBetId { get; set; }

		[JsonProperty("I")]
		public string Id { get; set; }

		[JsonProperty("N")]
		public string Title { get; set; }

		[JsonProperty("T")]
		public IList<League> Leagues { get; set; }
	}
}