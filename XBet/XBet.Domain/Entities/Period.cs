using System.ComponentModel.DataAnnotations.Schema;
using XBet.Core.Domain;

namespace XBet.Domain.Entities
{
	public class Period : ValueObject<Period>
	{
		public int? PeriodId { get; set; }

		public string Name { get; set; }

		public string ShortName { get; set; }

		public int Home { get; set; }

		public int Away { get; set; }

		[NotMapped]
		public int Both => Home + Away;

		[NotMapped]
		public bool IsOdd => Both % 2 != 0;

		public bool HasSameParity(Period another) => this.IsOdd == another.IsOdd;
	}
}
