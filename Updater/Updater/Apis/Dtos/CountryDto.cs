using Newtonsoft.Json;

namespace Updater.Apis.Dtos
{
	public class CountryDto : DtoBase
	{
		public CountryDto(int id, string title = null)
		{
			Id    = id;
			Title = title;
		}

		[JsonProperty("Title")]
		public string Title { get; set; }
	}
}