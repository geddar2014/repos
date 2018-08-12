using System;
using System.Net;
using System.Threading.Tasks;
using Pathoschild.Http.Client;

namespace ConsUpdater.Api
{
	public class HttpClientFactory
	{
		private const string BaseUri = "https://1xstavka.ru/statistic/";

		public static FluentClient Create()
		{
			var client = new FluentClient(BaseUri);
			client.SetOptions(new FluentClientOptions() { IgnoreHttpErrors = true, IgnoreNullArguments = true });
			client.SetRequestCoordinator(
				maxRetries: 5,
				shouldRetry: req => req.StatusCode != HttpStatusCode.OK,
				getDelay: (attempt, response) => TimeSpan.FromSeconds(attempt));
			return client;
		}

		public static async Task<T> FetchAsync<T>(string req, params object[] parameters)
		{
			using (var flu = Create())
			{
				req = parameters.Length > 0 ? string.Format(req, parameters) : req;

				var response = await flu.GetAsync(req).As<T>();

				return response;
			}
		}

		public static async Task<string> FetchAsync(string req, params object[] parameters)
		{
			using (var flu = Create())
			{
				req = parameters.Length > 0 ? string.Format(req, parameters) : req;

				return await flu.GetAsync(req).AsString();
			}
		}
	}
}