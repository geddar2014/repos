using System;

namespace Updater.Common
{
	public interface IHasCreationTime
	{
		DateTime CreationTime { get; set; }
	}
}