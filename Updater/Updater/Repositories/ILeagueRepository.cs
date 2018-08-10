using System.Collections.Generic;
using Updater.Apis.Dtos;

namespace Updater.Repositories
{
	public interface ILeagueRepository
	{
		void AddIfNotExists_Leagues(IList<LeagueDto> leaguesInput, out int inserted);

		void AddOrUpdate_Leagues(IList<LeagueDto> leaguesInput, out int inserted, out int updated);
	}
}