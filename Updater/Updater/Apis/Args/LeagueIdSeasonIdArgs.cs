namespace Updater.Apis.Args
{
	public class LeagueIdSeasonIdArgs : IRunnerArgs
	{
		protected LeagueIdSeasonIdArgs()
		{
		}

		private LeagueIdSeasonIdArgs(string leagueId, string seasonId)
		{
			LeagueId  = leagueId;
			SeasonId = seasonId;
		}
		
		public string LeagueId  { get; protected set; }

		public string SeasonId { get; protected set; }

		public IRunnerArgs Create(params object[] parameters)
		{
			return new LeagueIdSeasonIdArgs((string) parameters[0], (string) parameters[1]);
		}
		
		public static LeagueIdSeasonIdArgs Create(string leagueId, string seasonId)
		{
			return (LeagueIdSeasonIdArgs) new LeagueIdSeasonIdArgs().Create((object) leagueId, (object) seasonIdId);
		}
	}
}