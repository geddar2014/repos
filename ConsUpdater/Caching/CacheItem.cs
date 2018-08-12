using System;

namespace ConsUpdater.Caching
{
	public class CacheItem<T> : ICacheItem<T>
	{
		public CacheItem(DateTime lastUpdated, T value)
		{
			LastUpdated = lastUpdated;
			Value = value;
		}

		public DateTime LastUpdated { get; private set; }

		public T Value { get; private set; }
	}
}
