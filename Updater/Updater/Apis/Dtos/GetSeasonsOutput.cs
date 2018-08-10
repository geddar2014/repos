using Newtonsoft.Json;

namespace Updater.Apis.Dtos
{
	public class GetSeasonsOutput
	{
		[JsonConstructor]
		public GetSeasonsOutput(int id, string title, int champStageId)
		{
			Season = new SeasonDto(id, title, champStageId);
		}

		public SeasonDto Season { get; set; }
	}
}