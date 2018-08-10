using System;
using System.Collections.Generic;
using System.Linq;
using Insight.Database;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Updater.Apis.Dtos
{
	//[Recordset(typeof(GameDto), typeof(TeamDto), typeof(TeamDto))]
	[BindChildren(BindChildrenFor.All)]
	public class GameDto : DtoBase
	{
		[JsonConstructor]
		public GameDto(
				int score1,
				int score2,
				int team1Id,
				string team1,
				int teamCountry1,
				int xBetTeamId1,
				int team2Id,
				string team2,
				int teamCountry2,
				int xBetTeamId2,
				IList<PeriodDto> periods,
				int? champStageId = null)
		{
			TeamHomeId = team1Id;
			TeamAwayId = team2Id;
			TeamHome = new TeamDto
			{
					Id         = team1Id,
					CountryId  = teamCountry1,
					Title      = team1,
					XBetTeamId = xBetTeamId1
			};

			TeamAway = new TeamDto
			{
					Id         = team2Id,
					CountryId  = teamCountry2,
					Title      = team2,
					XBetTeamId = xBetTeamId2
			};

			if (periods != null)
			{
				if (periods.Count > 0)
				{
					P1_Home = periods[0].Home;
					P1_Away = periods[0].Away;
				}

				if (periods.Count > 1)
				{
					P2_Home = periods[1].Home;
					P2_Away = periods[1].Away;
				}

				if (periods.Count > 2)
				{
					P3_Home = periods[2].Home;
					P3_Away = periods[2].Away;
				}

				if (periods.Count > 3)
				{
					P4_Home = periods[3].Home;
					P4_Away = periods[3].Away;
				}

				if (periods.Count > 4)
				{
					OT_Home = periods[4].Home;
					OT_Away = periods[4].Away;
				}

				Total_Home = Math.Max(periods.Sum(x => x.Home), score1);
				Total_Away = Math.Max(periods.Sum(x => x.Away), score2);
			}

			else
			{
				Total_Home = score1;
				Total_Away = score2;
			}

			if (champStageId != null) StageId = champStageId.Value;
		}

		public GameDto()
		{
		}

		[JsonIgnore]
		public int CountryId { get; set; }

		[JsonIgnore]
		public int LeagueId { get; set; }

		[JsonIgnore]
		public int SeasonId { get; set; }

		[JsonIgnore]
		public int StageId { get; set; }

		[JsonIgnore]
		public TeamDto TeamHome { get; set; }

		[JsonIgnore]
		public TeamDto TeamAway { get; set; }

		[JsonIgnore]
		public int P1_Home { get; set; }

		[JsonIgnore]
		public int P1_Away { get; set; }

		[JsonIgnore]
		public int P2_Home { get; set; }

		[JsonIgnore]
		public int P2_Away { get; set; }

		[JsonIgnore]
		public int P3_Home { get; set; }

		[JsonIgnore]
		public int P3_Away { get; set; }

		[JsonIgnore]
		public int P4_Home { get; set; }

		[JsonIgnore]
		public int P4_Away { get; set; }

		[JsonIgnore]
		public int OT_Home { get; set; }

		[JsonIgnore]
		public int OT_Away { get; set; }

		[JsonIgnore]
		public int Total_Home { get; set; }

		[JsonIgnore]
		public int Total_Away { get; set; }

		public int TeamHomeId { get; set; }

		public int TeamAwayId { get; set; }

		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime DateStart { get; set; }

		[JsonProperty("State")]
		public int State { get; set; }
	}
}