using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsUpdater.Caching;
using ConsUpdater.Entities;

namespace ConsUpdater.Api
{
	public interface ISeasonsQuery
	{
		string LeagueId { get; set; }
		string RelPath { get; }

		Task<IEnumerable<Season>> GetAsync(ExpirePolicy policy, string leagueId);
		Func<SOutRoot, IEnumerable<Season>> Transform();
	}
}