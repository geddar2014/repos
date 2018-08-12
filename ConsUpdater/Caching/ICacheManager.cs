using System;
using System.Threading.Tasks;

namespace ConsUpdater.Caching
{
	public interface ICacheManager
	{
		TimeSpan DailyExpirationPolicy { get; }
		TimeSpan HistoryExpirationPolicy { get; }
		TimeSpan MemoryExpirationPolicy { get; }
		TimeSpan SeasonExpirationPolicy { get; }

		string Get(string key, ExpirePolicy policy);
		Task<string> GetAsync(string key, ExpirePolicy policy);
		void SetPolicies(TimeSpan? memory = null, TimeSpan? daily = null, TimeSpan? season = null, TimeSpan? history = null);
	}
}