using System.Collections.Generic;
using Updater.Apis.Dtos;

namespace Updater.Repositories
{
	public interface ISeasonRepository
	{
		void AddIfNotExists_Seasons(IList<SeasonDto> seasonsInput, out int inserted);

		void AddOrUpdate_Seasons(IList<SeasonDto> seasonsInput, out int inserted, out int updated);
	}
}