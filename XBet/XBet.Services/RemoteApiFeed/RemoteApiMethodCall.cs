using System;
using System.Threading.Tasks;
using ExpressMapper;
using ExpressMapper.Extensions;
using Newtonsoft.Json;
using ServiceStack;
using XBet.Services.RemoteFeed;
using XBet.Services.Repositories;

namespace XBet.Services.RemoteApiFeed
{
	public class RemoteApiRequest<TRemoteDto,TDomainObject>
	{
		private readonly IRemoteApiInfo _api;

		private readonly IRemoteApiRepository _apiRepository;

		private readonly IRemoteApiMethodInfo _methodInfo;

		private readonly IMappingServiceProvider _mapping;

		private RemoteApiRequest(IRemoteApiInfo api, IRemoteApiRepository apiRepository, IRemoteApiMethodInfo methodInfo, IMappingServiceProvider mapping)
		{
			_api = api;
			_apiRepository = apiRepository;
			_methodInfo = methodInfo;
			_mapping = mapping;
		}

		public TDomainObject Get(params object[] parameters)
		{
			return null;
		}

		public string GenerateUrl(params object[] parameters) => _api.BaseUrl.AppendUrlPathsRaw(_methodInfo.RelativeUrl.Fmt(parameters));

		public string GetString(string url) => _apiRepository.GetString(url);

		public async Task<string> GetStringAsync(string url) => await _apiRepository.GetStringAsync(url);

		public TRemoteDto ParseRemoteDto(string json) => JsonConvert.DeserializeObject<TRemoteDto>(json);

		public TDomainObject MapToDomainObject(TRemoteDto dto) => dto.Map<TRemoteDto, TDomainObject>();


		public TRemoteDto Call(params object[] parameters)
		{
			throw new System.NotImplementedException();
		}
	}
}
