using System;
using System.Linq;
using System.Threading.Tasks;
using ConsUpdater.Api;
using ConsUpdater.Caching;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsUpdater
{
	public class App
	{
		private readonly ILogger<App> _logger;
		private readonly ICountriesLeaguesQuery _clq;
		private readonly ISeasonsQuery _sq;
		private readonly  AppSettings _appSettings;
 
		public App(IOptions<AppSettings> appSettings, ILogger<App> logger, ICountriesLeaguesQuery clq, ISeasonsQuery sq)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_clq = clq;
			_sq = sq;
			_appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
		}
 
		public async Task Run()
		{
			var countries = await _clq.GetCountriesAsync();

			var leagues = await _clq.GetLeaguesAsync();

			var seasons = leagues.Select(x=>_sq.GetAsync(ExpirePolicy.History, x.Id)).ToList();

			await Task.CompletedTask;
		}
	}
}
