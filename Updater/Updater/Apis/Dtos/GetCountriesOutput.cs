using System.Collections.Generic;
using Newtonsoft.Json;

namespace Updater.Apis.Dtos
{
	public class GetCountriesOutput
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Title")]
		public string Title { get; set; }

		[JsonProperty("category")]
		public IList<CountryDto> Countries { get; set; }
	}
}