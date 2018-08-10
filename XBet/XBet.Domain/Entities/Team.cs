using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XBet.Domain.Entities
{
    public class Team
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

        public string Title { get; set; }

		public int XBetTeamId { get; set; }

		[ForeignKey(nameof(Country))]
	    public int CountryId { get; set; }

        public virtual Country Country { get; set; }

		public virtual List<Game> GamesHome { get; set; }=new List<Game>();

	    public virtual List<Game> GamesAway { get; set; } = new List<Game>();
	}
}
