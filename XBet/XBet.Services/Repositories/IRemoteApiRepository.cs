using System;
using System.Threading.Tasks;

namespace XBet.Services.Repositories
{
	public interface IRemoteApiRepository
	{
		string GetString(string url);

		Task<string> GetStringAsync(string url);
	}
}