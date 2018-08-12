namespace Updater.Apis.Args
{
	public class LeagueIdArgs : IRunnerArgs
	{
		protected LeagueIdArgs()
		{
		}

		private LeagueIdArgs(string leagueId)
		{
			LeagueId  = leagueId;
		}
		
		public string LeagueId  { get; protected set; }

		public IRunnerArgs Create(params object[] parameters)
		{
			return new LeagueIdArgs((string) parameters[0]);
		}
		
		public static LeagueIdArgs Create(string leagueId)
		{
			return (LeagueIdArgs) new LeagueIdArgs().Create((object) leagueId);
		}
	}
}