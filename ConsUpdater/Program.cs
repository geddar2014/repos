using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConsUpdater.Api;
using ConsUpdater.Caching;
using ConsUpdater.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// ReSharper disable InconsistentNaming

namespace ConsUpdater
{
	class Program
	{
		static void Main(string[] args)
		{
			var services = new ServiceCollection();

			ConfigureServices(services);

			var serviceProvider = services.BuildServiceProvider();
 
			Console.WriteLine("Hello World!");

			AsyncHelper.RunSync(async () => await serviceProvider.GetService<App>().Run());



			//		var resp = CountriesLeaguesQuery.GetResult();

//			var seasons = resp.Item2.SelectMany(l => new SeasonsQuery()..GetResult(l.Id));

			//Console.ReadLine();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			// add logging
			services.AddSingleton(
				new LoggerFactory()
					.AddConsole()
					.AddDebug()
			);
			services.AddLogging();

			services.AddTransient<ICountriesLeaguesQuery, CountriesLeaguesQuery>();
			services.AddTransient<ISeasonsQuery, SeasonsQuery>();
			services.AddMemoryCache();
			services.AddTransient<ICacheManager, CacheManager>();
			services.AddSingleton<AppSettings>();
 
			// build config
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", false)
				//.AddEnvironmentVariables()
				.Build();
 
			services.AddOptions();
			services.Configure<AppSettings>(configuration.GetSection("App"));
 
			// add app
			services.AddTransient<App>();
		}
	}
}
