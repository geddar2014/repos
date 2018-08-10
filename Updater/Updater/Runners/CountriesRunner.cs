using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Updater.Apis;
using Updater.Apis.Args;
using Updater.Apis.Dtos;
using Updater.UpdateResults;

namespace Updater.Runners
{
	public class CountriesRunner : Runner<EmptyArgs, IList<GetCountriesOutput>>
	{
		protected CountriesRunner(Result total = null) : base(total)
		{
			_total = total ?? new Result(EmptyArgs.Create(), RunnerType.Countries);
		}

		protected override async Task ProcessAsync(EmptyArgs args, Result result)
		{
			var fetch = (await GetAsync("Sport/3/Category?ln=ru"))
					.SelectMany(x => x.Countries)
					.ToList();

			if (fetch.Count > 0)
			{
				_db.CountryRepository.AddOrUpdate_Countries(
						fetch,
						out var countriesInserted,
						out var countriesUpdated);

				result.CountriesInserted = countriesInserted;
				result.CountriesUpdated  = countriesUpdated;
			}
		}

		public override async Task RunAsync()
		{
			_totalSteps = 1;
			await Round(EmptyArgs.Create());
		}


		public static void Run(Result total = null)
		{
			Task.Run(async () => await new CountriesRunner(total).RunAsync()).Wait();
			//AsyncHelper.RunSync(async () => await new CountriesRunner(total).RunAsync());
		}
	}
}