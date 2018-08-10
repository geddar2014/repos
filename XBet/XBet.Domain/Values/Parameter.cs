using XBet.Core.Domain;

namespace XBet.Domain.Values
{
	public class Parameter : ValueObject<Parameter>
	{
		public int Type { get; set; }

		public string Title { get; set; }
	
		public int HomeVal { get; set; }
	
		public int AwayVal { get; set; }
	
		public bool IsPercent { get; set; }
	}
}