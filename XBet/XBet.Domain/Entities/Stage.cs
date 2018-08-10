using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XBet.Domain.Entities
{
	public class Stage
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public string Title { get; set; }

		[ForeignKey(nameof(Country))]
		public int CountryId { get; set; }

		[ForeignKey(nameof(League))]
		public int LeagueId { get; set; }

		[ForeignKey(nameof(Season))]
		public int SeasonId { get; set; }

		public virtual Country Country { get; set; }

		public virtual League League { get; set; }

		public virtual Season Season { get; set; }

		public virtual IList<Game> Games { get; } = new List<Game>();
	}
}