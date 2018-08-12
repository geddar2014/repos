using System;

namespace ConsUpdater.Caching
{
	public interface ICacheItem<out T>
	{
		DateTime LastUpdated { get; }
		T Value { get; }
	}
}