using System;
using System.Linq;
using System.Threading.Tasks;
using Insight.Database;
using Newtonsoft.Json;
using Updater.Apis;
using Updater.Apis.Args;
using Updater.Apis.Dtos;
using Updater.Common;
using Updater.UpdateResults;

namespace Updater.Runners
{
	public class StageTeamGameRunner : Runner<CountryIdLeagueIdSeasonIdArgs, GetStagesGamesTeamsOutput>
	{
		protected StageTeamGameRunner(Result total = null) : base(total)
		{
			_total = total ?? new Result(EmptyArgs.Create(), RunnerType.Seasons);
		}

		protected override async Task ProcessAsync(CountryIdLeagueIdSeasonIdArgs args, Result result)
		{
			var dto = await GetAsync($"ChampSeason/{args.SeasonId}/Game/5000/0?ln=ru");

			foreach (var g in dto.Games)
			{
				g.CountryId = args.CountryId;
				g.LeagueId  = args.LeagueId;
				g.SeasonId  = args.SeasonId;
			}

			foreach (var s in dto.Stages)
			{
				s.CountryId = args.CountryId;
				s.LeagueId  = args.LeagueId;
				s.SeasonId  = args.SeasonId;
			}

			#region countries

			var countries = dto.Teams.Select(x => x.CountryId).Distinct().Select(x => new CountryDto(x))
					.ToList();

			if (countries.Count > 0)
			{
				_db.CountryRepository.AddIfNotExists_Countries(countries, out var countriesInserted);
				result.CountriesInserted = countriesInserted;
			}

			#endregion

			#region stages

			var stages = dto.Stages;

			if (stages.Count > 0)
			{
				_db.StageRepository.AddOrUpdate_Stages(stages, out var stagesInserted, out var stagesUpdated);
				result.StagesInserted = stagesInserted;
				result.StagesUpdated  = stagesUpdated;
			}

			#endregion

			#region Teams

			var teams = dto.Teams.ToList();

			if (teams.Count > 0)
			{
				_db.TeamRepository.AddOrUpdate_Teams(teams, out var teamsInserted, out var teamsUpdated);
				result.TeamsInserted = teamsInserted;
				result.TeamsUpdated  = teamsUpdated;
			}

			#endregion

			#region Games

			var games = dto.Games;

			if (games.Count > 0)
			{
				_db.GameRepository.AddOrUpdate_Games(games, out var gamesInserted, out var gamesUpdated);
				result.GamesInserted = gamesInserted;
				result.GamesUpdated  = gamesUpdated;
			}

			#endregion
		}


		public override async Task RunAsync()
		{
			var updatedCountryIdLeagueIdSeasonIds = _db.Connection
					.QuerySql<string>(
							$"SELECT Args FROM UpdateResults WHERE RunnerType = {(int) RunnerType.StagesGamesTeams}")
					.Distinct().Select(JsonConvert.DeserializeObject<CountryIdLeagueIdSeasonIdArgs>)
					.OrderBy(x => x.CountryId).ThenBy(x => x.LeagueId).ThenBy(x => x.SeasonId).ToList();

			var query = _db.Connection
					.QuerySql<SeasonDto>("SELECT CountryId, LeagueId, Id FROM Seasons");

			var allCountryIdLeagueIdSeasonIds = query
					.Select(x =>
							CountryIdLeagueIdSeasonIdArgs.Create(x.CountryId,
									x.LeagueId, x.Id))
					.OrderBy(x => x.CountryId).ThenBy(x => x.LeagueId).ThenBy(x => x.SeasonId).ToList();

			var unfetchedCountryIdLeagueIdSeasonIds =
					allCountryIdLeagueIdSeasonIds
							//.Except(updatedCountryIdLeagueIdSeasonIds)
							.ToList();

			_totalSteps = unfetchedCountryIdLeagueIdSeasonIds.Count;

			_currentStep = 0;
			var dt = DateTime.Now;
			await unfetchedCountryIdLeagueIdSeasonIds.ForEachAsync(THREADS, async item => await Round(item));
			var log = $"{THREADS} threads: {(DateTime.Now - dt).Seconds}";
			Console.WriteLine(log);

			//for (var i = 0; i < _totalSteps; i++) await Round(unfetchedCountryIdLeagueIdSeasonIds[i]);
		}

		public static void Run(Result total = null)
		{
			Task.Run(async () => await new StageTeamGameRunner(total).RunAsync()).Wait();
		}
	}
}