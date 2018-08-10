using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XBet.Domain.Entities
{
    /// <summary>
    /// https://1xstavka.ru/StatisticFeed/Sport/3/Category/200/Champ?ln=ru
    /// </summary>
    /// 
	public class League
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

        public string Title { get; set; }

		[ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

	    public virtual Country Country { get; set; }

		public virtual IList<Season> Seasons { get; } = new List<Season>();

		public virtual IList<Stage> Stages { get; } = new List<Stage>();

		public virtual IList<Game> Games { get; } = new List<Game>();

	}

}