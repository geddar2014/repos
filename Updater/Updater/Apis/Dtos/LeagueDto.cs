using Newtonsoft.Json;

namespace Updater.Apis.Dtos
{
	public class LeagueDto : DtoBase
	{
		public LeagueDto()
		{
		}

		[JsonConstructor]
		public LeagueDto(int id, string msTitle)
		{
			Id    = id;
			Title = msTitle;
		}

		public LeagueDto(int id, int countryId)
		{
			Id        = id;
			CountryId = countryId;
		}

		public int CountryId { get; set; }

		public string Title { get; set; }
	}
}