using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XBet.Domain.Entities
{
    /// <summary>
    /// https://1xstavka.ru/StatisticFeed/Champ/372/Season?ln=ru
    /// </summary>

    public class Season
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
        
		public int XBetSeasonId { get; set; }

        public string Title { get; set; }

		[ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

		[ForeignKey(nameof(League))]
        public int LeagueId { get; set; }
        
		//[ForeignKey(nameof(LastStage))]
        public int? LastStageId { get; set; }

	    public virtual Country Country { get; set; }

        public virtual League League { get; set; }

        //public virtual Stage LastStage { get; set; }

		public virtual IList<Stage> Stages { get; } = new List<Stage>();

		public virtual IList<Game> Games { get; } = new List<Game>();
	}

}