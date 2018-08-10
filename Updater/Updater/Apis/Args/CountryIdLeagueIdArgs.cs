namespace Updater.Apis.Args
{
	public class CountryIdLeagueIdArgs : IRunnerArgs
	{
		protected CountryIdLeagueIdArgs()
		{
		}

		private CountryIdLeagueIdArgs(int countryId, int leagueId)
		{
			CountryId = countryId;
			LeagueId  = leagueId;
		}

		public int CountryId { get; protected set; }
		public int LeagueId  { get; protected set; }

		public IRunnerArgs Create(params object[] parameters)
		{
			return new CountryIdLeagueIdArgs((int) parameters[0], (int) parameters[1]);
		}


		public static CountryIdLeagueIdArgs Create(int countryId, int leagueId)
		{
			return (CountryIdLeagueIdArgs) new CountryIdLeagueIdArgs().Create((object) countryId, (object) leagueId);
		}
	}
}