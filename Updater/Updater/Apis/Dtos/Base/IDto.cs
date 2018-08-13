using Updater.Common;

namespace Updater.Apis.Dtos.Base
{
	public interface IDto : IHasId
	{
	}

    public interface IDtoWithTitle : IDto, IHasTitle
    {
    }
}