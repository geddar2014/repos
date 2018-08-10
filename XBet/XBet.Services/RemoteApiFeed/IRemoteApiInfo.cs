using System.Collections.Generic;

namespace XBet.Services.RemoteFeed
{
	public interface IRemoteApiInfo
	{
		string Name { get; }

		IDictionary<string, IRemoteApiMethodInfo> ApiMethods { get; }

		string BaseUrl { get; }
	}
}