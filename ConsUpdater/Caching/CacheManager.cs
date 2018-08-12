using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ConsUpdater.Api;
using ConsUpdater.Common;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ConsUpdater.Caching
{
	public class CacheManager : ICacheManager
	{
		private readonly string _cachePath;
		private readonly IMemoryCache _memoryCache;
		private readonly AppSettings _appSettings;

		public TimeSpan MemoryExpirationPolicy { get; private set; }
		public TimeSpan DailyExpirationPolicy { get; private set; }
		public TimeSpan SeasonExpirationPolicy { get; private set; }
		public TimeSpan HistoryExpirationPolicy { get; private set; }


		public void SetPolicies(TimeSpan? memory = null, TimeSpan? daily = null, TimeSpan? season = null,
			TimeSpan? history = null)
		{
			MemoryExpirationPolicy = memory ?? _appSettings.MemoryDefault;
			DailyExpirationPolicy = daily ?? _appSettings.DailyDefault;
			SeasonExpirationPolicy = season ?? _appSettings.SeasonDefault;
			HistoryExpirationPolicy = history ?? _appSettings.HistoryDefault;
		}

		public CacheManager(IMemoryCache memoryCache, AppSettings settings, AppSettings appSettings)
		{
			_memoryCache = memoryCache;
			_appSettings = appSettings;
			_cachePath = _appSettings.CacheDirectory.ToApplicationPath();

			if (!Directory.Exists(_cachePath))
			{
				Directory.CreateDirectory(_cachePath);
			}
		}

		public string Get(string key, ExpirePolicy policy)
		{
			return AsyncHelper.RunSync(async ()=> await GetAsync(key, policy));
		}

		public async Task<string> GetAsync(string key, ExpirePolicy policy)
		{
			TimeSpan span;

			switch (policy)
			{
				default:
				case ExpirePolicy.Never:
					span = TimeSpan.FromDays(1000);
					break;
				case ExpirePolicy.Memory:
					span = MemoryExpirationPolicy == default(TimeSpan) ? _appSettings.MemoryDefault : MemoryExpirationPolicy;
					break;
				case ExpirePolicy.Daily:
					span = DailyExpirationPolicy == default(TimeSpan) ? _appSettings.DailyDefault : DailyExpirationPolicy;
					break;
				case ExpirePolicy.Season:
					span = SeasonExpirationPolicy == default(TimeSpan) ? _appSettings.SeasonDefault : SeasonExpirationPolicy;
					break;
				case ExpirePolicy.History:
					span = HistoryExpirationPolicy == default(TimeSpan) ? _appSettings.HistoryDefault : HistoryExpirationPolicy;
					break;
			}

			return await GetFromMemoryOrUpdate(key, span);
		}

		private async Task<string> GetFromMemoryOrUpdate(string key, TimeSpan policy)
		{
			if (_memoryCache.TryGetValue(key, out _string cacheEntry) && DateTime.Now < cacheEntry.LastUpdated.Add(policy))
				return cacheEntry.Value;

			var item = await GetFromDiskOrFetch(key, policy);

			return _memoryCache.Set(key, item, policy);
		}

		private async Task<string> GetFromDiskOrFetch(string key, TimeSpan policy)
		{
			var fi = MD5HashedFi(key);

			if (fi.Exists && DateTime.Now < fi.CreationTime.Add(policy))
			{
				return await File.ReadAllTextAsync(fi.FullName, Encoding.UTF8);
			}
			return await FetchAndWriteToDisk(key);
		}

		private async Task<string> FetchAndWriteToDisk(string key)
		{
			var ret = await HttpClientFactory.FetchAsync(key);

			var fi = MD5HashedFi(key);

			if (fi.Exists) fi.Delete();

			await File.WriteAllTextAsync(fi.FullName, ret, Encoding.UTF8);

			return ret;
		}

		private FileInfo MD5HashedFi(string key)
		{
			var keyBytes = key.ToByteArray();

			var md5Hash = keyBytes.ToMD5Hash();

			var ret = Path.Combine(_cachePath, $"{md5Hash}.json");

			return new FileInfo(ret);
		}
	}
}