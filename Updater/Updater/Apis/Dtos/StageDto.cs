using Newtonsoft.Json;

namespace Updater.Apis.Dtos
{
	public class StageDto : DtoBase
	{
		public StageDto(int champStageId, string stageTitle, int champSeasonId, int categoryId, int champId) : this(
				champStageId, stageTitle)
		{
			SeasonId  = champSeasonId;
			CountryId = categoryId;
			LeagueId  = champId;
		}

		[JsonConstructor]
		public StageDto(int id, string title, bool? isNet = null, bool? needChessTable = null)
		{
			Id    = id;
			Title = title;
		}


		public string Title { get; set; }

		public int SeasonId { get; set; }

		public int CountryId { get; set; }

		public int LeagueId { get; set; }
	}
}