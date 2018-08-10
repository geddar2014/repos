using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XBet.Domain.Enums;

namespace XBet.Domain.Entities
{
	public class Game
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public DateTime DateStart { get; set; }

		public CompletionState State { get; set; }

		public int P1Home { get; set; }

		public int P1Away { get; set; }

		public int P2Home { get; set; }

		public int P2Away { get; set; }

		public int P3Home { get; set; }

		public int P3Away { get; set; }

		public int P4Home { get; set; }

		public int P4Away { get; set; }

		[NotMapped]
		public int TotalHome => P1Home + P2Home + P3Home + P4Home;

		[NotMapped]
		public int TotalAway => P1Away + P2Away + P3Away + P4Away;

		public Score Total => new Score(TotalHome, TotalAway);


		public Score P1 => new Score(P1Home, P1Away);

		public Score P2 => new Score(P2Home, P2Away);

		public Score P3 => new Score(P3Home, P3Away);

		public Score P4 => new Score(P4Home, P4Away);

		[ForeignKey(nameof(Country))]
		public int CountryId { get; set; }
		[ForeignKey(nameof(League))]
		public int LeagueId { get; set; }
		[ForeignKey(nameof(Season))]
		public int SeasonId { get; set; }
		[ForeignKey(nameof(Stage))]
		public int StageId { get; set; }

		public int TeamHomeId { get; set; }

		public int TeamAwayId { get; set; }

		//public virtual List<Period> Periods { get; set; } = new List<Period>();
		public virtual Stage Stage { get; set; }
		public virtual Season Season { get; set; }
		public virtual League League { get; set; }
		public virtual Country Country { get; set; }

		[ForeignKey(nameof(TeamHomeId))]
		[InverseProperty("GamesHome")]
		public virtual Team TeamHome { get; set; }

		[ForeignKey(nameof(TeamAwayId))]
		[InverseProperty("GamesAway")]
		public virtual Team TeamAway { get; set; }
	}

}