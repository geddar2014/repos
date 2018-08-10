using Updater.Repositories;

namespace Updater.Common
{
	public interface IDto : IHasCreationTime, IHasId, ISoftDelete
	{
	}
}