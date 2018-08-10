namespace Updater.Apis.Args
{
	public class CountryIdLeagueIdSeasonIdArgs : IRunnerArgs
	{
		protected CountryIdLeagueIdSeasonIdArgs()
		{
		}

		private CountryIdLeagueIdSeasonIdArgs(int countryId, int leagueId, int seasonId)
		{
			CountryId = countryId;
			LeagueId  = leagueId;
			SeasonId  = seasonId;
		}

		public int CountryId { get; protected set; }
		public int LeagueId  { get; protected set; }
		public int SeasonId  { get; protected set; }

		public IRunnerArgs Create(params object[] parameters)
		{
			return new CountryIdLeagueIdSeasonIdArgs((int) parameters[0], (int) parameters[1], (int) parameters[2]);
		}

		public static CountryIdLeagueIdSeasonIdArgs Create(int countryId, int leagueId, int seasonId)
		{
			return (CountryIdLeagueIdSeasonIdArgs) new CountryIdLeagueIdSeasonIdArgs().Create((object) countryId,
					(object) leagueId, (object) seasonId);
		}
	}
}