using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XBet.Domain.Entities
{
	public class Country
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

        public string Title { get; set; }

		public virtual IList<League> Leagues { get; } = new List<League>();

		public virtual IList<Season> Seasons { get; } = new List<Season>();

		public virtual IList<Stage> Stages { get; } = new List<Stage>();

		public virtual IList<Game> Games { get; } = new List<Game>();
	}


}