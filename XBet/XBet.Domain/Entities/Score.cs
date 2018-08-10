namespace XBet.Domain.Entities
{
    public struct Score
    {
	    public Score(int home, int away)
	    {
		    Home = home;
		    Away = away;
	    }

        public int Home { get; set; }

        public int Away { get; set; }

        public int Both => Home + Away;

        public bool IsOdd => Both % 2 != 0;

        public bool HasSameParity(Score another) => IsOdd == another.IsOdd;
    }
}
