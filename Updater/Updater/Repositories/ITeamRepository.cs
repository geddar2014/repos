using System.Collections.Generic;
using Updater.Apis.Dtos;

namespace Updater.Repositories
{
	public interface ITeamRepository
	{
		void AddOrUpdate_Teams(IList<TeamDto> teamsInput, out int inserted, out int updated);
		void Insert_Teams(IList<TeamDto> teamList);
		void Update_Teams(IList<TeamDto> teamList);
	}
}