using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsUpdater.Caching;
using ConsUpdater.Common;
using ConsUpdater.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

namespace ConsUpdater.Api
{
	public class
		CountriesLeaguesQuery : QueryBase<CLOutRoot, (IEnumerable<Country>, IEnumerable<League>)>, ICountriesLeaguesQuery
	{
		public override string RelPath => _settings.UriCountriesLeaguesRel;

		public override Func<CLOutRoot, (IEnumerable<Country>, IEnumerable<League>)> Transform() => c =>
		 {
			 var countries = c.OutStats.Countries;
			 var leagues = countries.SelectMany(cn => cn.Leagues.Select(l =>
			 {
				 l.CountryId = cn.Id;
				 return l;
			 }));
			 return (countries, leagues);
		 };

		public async Task<IList<Country>> GetCountriesAsync() => (await this.GetAsync(ExpirePolicy.Never, Array.Empty<object>())).Item1.ToList();

		public async Task<IList<League>> GetLeaguesAsync() => (await this.GetAsync(ExpirePolicy.Never, Array.Empty<object>())).Item2.ToList();


		public CountriesLeaguesQuery(ICacheManager cacheManager, AppSettings settings, ILoggerFactory loggerFactory) : base(cacheManager, settings, loggerFactory)
		{
		}
	}
	public sealed class CLOutRoot
	{
		[JsonProperty("statistic")] public CLOutStats OutStats { get; set; }

		public sealed class CLOutStats
		{
			[JsonProperty("S")] public IList<Country> Countries { get; set; }
		}
	}
}