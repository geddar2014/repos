using System;
using System.Threading.Tasks;
using ConsUpdater.Caching;
using ConsUpdater.Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pathoschild.Http.Client;

namespace ConsUpdater.Api
{
	public interface IQueryBase<in TRoot, TResult>
	{
		Func<TRoot, TResult> Transform();
		string RelPath { get; }
		Task<TResult> GetAsync(ExpirePolicy policy, params object[] args);
		TResult Get(ExpirePolicy policy, params object[] args);
	}

	public abstract class QueryBase<TRoot, TResult> : IQueryBase<TRoot, TResult>
	{
		protected readonly ICacheManager _cacheManager;

		protected readonly AppSettings _settings;

		protected readonly ILogger<QueryBase<TRoot, TResult>> _logger;

		public abstract Func<TRoot, TResult> Transform();

		public abstract string RelPath { get; }


		protected QueryBase(ICacheManager cacheManager, AppSettings settings, ILoggerFactory loggerFactory) : base()
		{
			_cacheManager = cacheManager;
			_settings = settings;
			_logger = loggerFactory.CreateLogger<QueryBase<TRoot, TResult>>();
		}

		protected virtual async Task<string> GetStringAsync(ExpirePolicy policy, string relPath, params object[] args)
		{
			var key = args.Length > 0 ? string.Format(relPath, args) : relPath;

			return await _cacheManager.GetAsync(key, policy);
		}

		public virtual async Task<TResult> GetAsync(ExpirePolicy policy, params object[] args)
		{
			var key = args.Length > 0 ? string.Format(RelPath, args) : RelPath;

			var json = await _cacheManager.GetAsync(key, policy);

			var root = JsonConvert.DeserializeObject<TRoot>(json);

			return Transform().Invoke(root);
		}

		public virtual TResult Get(ExpirePolicy policy, params object[] args)
		{
			return AsyncHelper.RunSync(async () => await GetAsync(policy, args));
		}

		
	}
}