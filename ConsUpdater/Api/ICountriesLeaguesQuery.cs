using System.Collections.Generic;
using System.Threading.Tasks;
using ConsUpdater.Entities;

namespace ConsUpdater.Api
{
	public interface ICountriesLeaguesQuery
	{
		Task<IList<Country>> GetCountriesAsync(); //string RelPath { get; }

		Task<IList<League>> GetLeaguesAsync();
		//System.Func<CLOutRoot, (IEnumerable<Country>, IEnumerable<League>)> Transform();
	}
}