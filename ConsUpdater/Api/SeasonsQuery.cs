using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsUpdater.Caching;
using ConsUpdater.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ConsUpdater.Api
{
	public class SeasonsQuery : QueryBase<SOutRoot, IEnumerable<Season>>, ISeasonsQuery
	{
		public override string RelPath => _settings.UriSeasonsRel;

		public string LeagueId { get; set; }

		public override Func<SOutRoot, IEnumerable<Season>> Transform() => c => c.OutStats.Seasons.Select(s =>
		{
			s.LeagueId = LeagueId;
			return s;
		});

		public async Task<IEnumerable<Season>> GetAsync(ExpirePolicy policy, string leagueId)
		{
			LeagueId = leagueId;
			return await base.GetAsync(policy, leagueId);
		}

		public SeasonsQuery(ICacheManager cacheManager, AppSettings settings, ILoggerFactory loggerFactory) : base(cacheManager, settings, loggerFactory)
		{
		}
	}
	public sealed class SOutRoot
	{
		[JsonProperty("statistic")] public SOutStats OutStats { get; set; }

		public sealed class SOutStats
		{
			[JsonProperty("N")] public IList<Season> Seasons { get; set; }
		}
	}
}