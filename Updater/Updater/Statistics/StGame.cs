using System;
using Insight.Database;
using Updater.Statistics;

namespace Updater.Apis.Dtos
{
	public class Country
	{
		[RecordId]
		public int Id { get; set; }

		public string Title { get; set; }

		public override string ToString()
		{
			return $"[{Id}] {Title}";
		}
	}

	public class League
	{
		[RecordId]
		public int Id { get; set; }

		[ParentRecordId]
		public int CountryId { get; set; }

		public string Title { get; set; }

		public override string ToString()
		{
			return $"[{Id}] {Title}";
		}
	}

	public class Season
	{
		[RecordId]
		public int Id { get; set; }

		[ParentRecordId]
		public int CountryId { get; set; }

		[ParentRecordId]
		public int LeagueId { get; set; }

		public string Title { get; set; }

		public override string ToString()
		{
			return $"[{Id}] {Title}";
		}
	}

	public class Stage
	{
		[RecordId]
		public int Id { get; set; }

		[ParentRecordId]
		public int CountryId { get; set; }

		[ParentRecordId]
		public int LeagueId { get; set; }

		[ParentRecordId]
		public int SeasonId { get; set; }

		public string Title { get; set; }

		public override string ToString()
		{
			return $"[{Id}] {Title}";
		}
	}

	public class Team
	{
		[RecordId]
		public int Id { get; set; }

		[ParentRecordId]
		public int CountryId { get; set; }

		public string Title { get; set; }

		public override string ToString()
		{
			return $"[{Id}] {Title}";
		}
	}

	[BindChildren(BindChildrenFor.All)]
	public class Game
	{
		[RecordId]
		public int Id { get; set; }
		public DateTime DateStart { get; set; }
		public Country Country { get; set; }
		public League League { get; set; }
		public Season Season { get; set; }
		public Stage Stage { get; set; }
		public Team TeamHome { get; set; }
		public Team TeamAway { get; set; }

		public Period P1 { get; set; }
		public Period P2 { get; set; }
		public Period P3 { get; set; }
		public Period P4 { get; set; }
		public Period OT { get; set; }
		public Period Total { get; set; }

		public override string ToString()
		{
			return $"{DateStart.ToShortDateString()} {DateStart.ToShortTimeString()} ({P1.Home}:{P1.Away}, {P2.Home}:{P2.Away}, {P3.Home}:{P3.Away}, {P4.Home}:{P4.Away}{(OT.Both > 0 ? ", " + OT.Home + ":" + OT.Away : "")}) ({Total.Home}:{Total.Away}) ({(Total.BothIsOdd ? "нечет" : "чет")})";
		}
	}
}