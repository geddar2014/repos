using System.Data;
using System.Data.SqlClient;
using Insight.Database;
using Updater.UpdateResults;

namespace Updater.Repositories
{
	public class DbInsight
	{
		private const string connStr =
				"Server=mi3-wsq2.a2hosting.com;Database=betcahos_new;User ID=betcahos_sa;Password=Pa$$w0rd123";
//				"Server=localhost; Database=BetAppDb; Trusted_Connection=True; User ID=sa; Password=Pa$$w0rd123;";

		public DbInsight()
		{
			SqlInsightDbProvider.RegisterProvider();

			Connection = new SqlConnection(connStr);

			CountryRepository   = Connection.AsParallel<ICountryRepository>();
			LeagueRepository    = Connection.AsParallel<ILeagueRepository>();
			SeasonRepository    = Connection.AsParallel<ISeasonRepository>();
			GameRepository      = Connection.AsParallel<IGameRepository>();
			StageRepository     = Connection.AsParallel<IStageRepository>();
			TeamRepository      = Connection.AsParallel<ITeamRepository>();
			ResultRepository    = Connection.AsParallel<IResultRepository>();
			SpanStatsRepository = Connection.AsParallel<ISpanStatsRepository>();
		}

		public IDbConnection        Connection          { get; }
		public ICountryRepository   CountryRepository   { get; }
		public ILeagueRepository    LeagueRepository    { get; }
		public ISeasonRepository    SeasonRepository    { get; }
		public IGameRepository      GameRepository      { get; }
		public IStageRepository     StageRepository     { get; }
		public ITeamRepository      TeamRepository      { get; }
		public IResultRepository    ResultRepository    { get; }
		public ISpanStatsRepository SpanStatsRepository { get; }
	}
}