using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insight.Database;
using Newtonsoft.Json;
using Serilog;
using Updater.Apis;
using Updater.Apis.Args;
using Updater.Apis.Dtos;
using Updater.Common;
using Updater.UpdateResults;

namespace Updater.Runners
{
	public class SeasonsRunner : Runner<CountryIdLeagueIdArgs, IList<GetSeasonsOutput>>
	{
		protected SeasonsRunner(Result total = null) : base(total)
		{
			_total = total ?? new Result(EmptyArgs.Create(), RunnerType.Seasons);
		}

		protected override async Task ProcessAsync(CountryIdLeagueIdArgs args, Result result)
		{
			var seasonsUri = $"Champ/{args.LeagueId}/Season?ln=ru";

			var seasons = (await GetAsync(seasonsUri)).Select(x => x.Season).GroupBy(x => x.XBetSeasonId)
					.Select(x => x.First()).ToList();

			foreach (var seasonDto in seasons)
			{
				var url =
						$"Category/{args.CountryId}/Champ/{args.LeagueId}/Season/{seasonDto.XBetSeasonId}/ChampSeasonId?ln=ru";

				var id = await GetAsync<int>(url);
				// new FluentClient(baseUri).GetAsync(url).As<int>();
				//AsyncHelper.RunSync(async () => await new FluentClient(baseUri).GetAsync(url).As<int>());

				seasonDto.Id        = id;
				seasonDto.CountryId = args.CountryId;
				seasonDto.LeagueId  = args.LeagueId;
			}

			if (seasons.Count > 0)
			{
				_db.SeasonRepository.AddOrUpdate_Seasons(seasons, out var seasonsInserted, out var seasonsUpdated);
				result.SeasonsInserted = seasonsInserted;
				result.SeasonsUpdated  = seasonsUpdated;
			}
		}

		public override async Task RunAsync()
		{
			var updatedCountryIdLeagueIds = _db.Connection
					.QuerySql<string>(
							$"SELECT Args FROM UpdateResults WHERE RunnerType = {(int) RunnerType.Seasons}")
					.Distinct()
					.Select(JsonConvert.DeserializeObject<CountryIdLeagueIdArgs>)
					.OrderBy(x => x.CountryId)
					.ThenBy(x => x.LeagueId);

			var query = _db.Connection
					.QuerySql<LeagueDto>("SELECT CountryId, Id FROM Leagues");

			var allCountryIdLeagueIds = query
					.Select(x => CountryIdLeagueIdArgs.Create(x.CountryId, x.Id))
					.OrderBy(x => x.CountryId)
					.ThenBy(x => x.LeagueId);

			var unfetchedCountryIdLeagueIds =
					allCountryIdLeagueIds
							//.Except(updatedCountryIdLeagueIds)
							.ToList();

			_totalSteps = unfetchedCountryIdLeagueIds.Count;

			_currentStep = 0;
			var dt = DateTime.Now;
			await unfetchedCountryIdLeagueIds.ForEachAsync(THREADS, async item => await Round(item));

			var log = $"{THREADS} threads: {(DateTime.Now - dt).Seconds}";

			Console.WriteLine(log);
			Log.Information(log);
		}

		public static void Run(Result total = null)
		{
			Task.Run(async () => await new SeasonsRunner(total).RunAsync()).Wait();
		}
	}
}