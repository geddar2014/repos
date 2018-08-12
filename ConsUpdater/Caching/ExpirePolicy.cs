namespace ConsUpdater.Caching
{
	public enum ExpirePolicy : byte
	{
		Never = 0,
		Memory = 1,
		Daily = 2,
		Season = 3,
		History = 4
	}
}