using System;

namespace ConsUpdater
{
	public class AppSettings
	{
		public TimeSpan MemoryDefault { get; set; } = TimeSpan.FromMinutes(1);
		public TimeSpan DailyDefault { get; set; } = TimeSpan.FromMinutes(5);
		public TimeSpan SeasonDefault { get; set; } = TimeSpan.FromHours(12);
		public TimeSpan HistoryDefault { get; set; } = TimeSpan.FromDays(15);
		public string CacheDirectory { get; set; } = "DataCache";
		public string UriBase { get; set; } = "https://1xstavka.ru/statistic/";
		public string UriCountriesLeaguesRel { get; set; } = "component_data/2/3-0-0-0-0-0-0";
		public string UriSeasonsRel { get; set; } = "component_data/3/3-{0}-0-0-0-0-0";
		public string UriStagesTeamsGamesRel { get; set; } = "component_data/3/3-{0}-{1}-0-0-0-0";
		public string UriDayTopMatchesRel { get; set; } = "top_matches_data/?sport_id=3&date={0}";
	}
}