namespace Updater.Apis.Args
{
	public class GameIdArgs : IRunnerArgs
	{
		protected GameIdArgs()
		{
		}

		private GameIdArgs(int gameId)
		{
			GameId = gameId;
		}

		public int GameId { get; protected set; }

		public IRunnerArgs Create(params object[] parameters)
		{
			return new GameIdArgs((int) parameters[0]);
		}

		public static GameIdArgs Create(int gameId)
		{
			return (GameIdArgs) new GameIdArgs().Create((object) gameId);
		}
	}
}