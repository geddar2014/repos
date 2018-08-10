using System.Threading.Tasks;
using ServiceStack;

namespace XBet.Services.Repositories
{
	public class RemoteApiRepository : IRemoteApiRepository
	{
		public string GetString(string url) => url.GetJsonFromUrl();

		public async Task<string> GetStringAsync(string url) => await url.GetJsonFromUrlAsync();
	}
}
