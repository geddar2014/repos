using Updater.Repositories;

namespace Updater.Common
{
	public interface IDto : IHasId
	{
	}

    public interface IDtoWithTitle : IDto, IHasTitle
    {
    }
}