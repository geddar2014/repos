using Newtonsoft.Json;

namespace Updater.Apis.Dtos
{
	public class SeasonDto : DtoBase
	{
		[JsonConstructor]
		public SeasonDto(int id, string title, int champStageId)
		{
			XBetSeasonId = id;
			Title        = title;
			LastStageId  = champStageId;
		}

		public SeasonDto()
		{
		}

		public SeasonDto(int id, int countryId, int leagueId)
		{
			Id        = id;
			CountryId = countryId;
			LeagueId  = leagueId;
		}

		[JsonIgnore]
		public int CountryId { get; set; }

		[JsonIgnore]
		public int LeagueId { get; set; }

		[JsonProperty("ChampStageId")]
		public int? LastStageId { get; set; }

		[JsonProperty("Id")]
		public int XBetSeasonId { get; set; }

		[JsonProperty("Title")]
		public string Title { get; set; }
	}
}