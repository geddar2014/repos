using System;
using System.Collections.Generic;

namespace XBet.Services.RemoteFeed
{
	public interface IRemoteApiMethodInfo
	{
		string Name { get; }

		string  RelativeUrl { get; }

		IDictionary<string, Type> ParameterInfo { get; }

		Type ApiResponseType { get; }
	}
}