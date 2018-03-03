using SalaryCapData.ConsumeJson.Models.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static SalaryCapData.ConsumeJson.Models.Game.HitterPoints;

namespace SalaryCapData.Models
{
    public class Player
    {
        [DatabaseGenerated( DatabaseGeneratedOption.None )]
        public int Id { get; set; }
        //public string PlayerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public bool IsRookie { get; set; }
        public string Position { get; set; }
        public decimal InitialValue { get; set; }
		public int TotalPoints { get; set; }
		//{
		//	get { return TotalPoints; }
		//	set
		//	{
		//		TotalPoints = GetHitterPoints();

		//	}
		//}
		//public decimal CurrentValue { get; set; }
		public int TeamId { get; set; }
        public Team Team { get; set; }
		public HitterStats HitterStats { get; set; }
        public PitcherStats PitcherStats { get; set; }
		//public IEnumerable<PlayerPosition> PlayerPositions { get; set; }

		public int GetPitcherPoints()
		{
			if ( this.PitcherStats != null )
			{
				int hitsPoints = this.PitcherStats.HitsAllowed * (int)GamePoints.PitcherPointValues.Hit;
				int runPoints = this.PitcherStats.EarnedRunsAllowed * (int)GamePoints.PitcherPointValues.Run;
				int WinsPoints = this.PitcherStats.Wins * (int)GamePoints.PitcherPointValues.Win;
				int completeGamesPoints = this.PitcherStats.CompleteGames * (int)GamePoints.PitcherPointValues.CompleteGamne;
				int LosesPoints = this.PitcherStats.Loses * (int)GamePoints.PitcherPointValues.Loss;
				int HoldsPoints = this.PitcherStats.Holds * (int)GamePoints.PitcherPointValues.Hold;
				int walkPoints = this.PitcherStats.PitcherWalks * (int)GamePoints.PitcherPointValues.Walk;
				int IPPoints = (int)this.PitcherStats.InningsPitched * (int)GamePoints.PitcherPointValues.InningPitched;
				int strikeoutPoints = this.PitcherStats.Strikeouts * (int)GamePoints.PitcherPointValues.SO;
								
				return (hitsPoints
						+ runPoints
						+ WinsPoints
						+ completeGamesPoints
						+ LosesPoints
						+ walkPoints
						//+ IPPoints
						+ strikeoutPoints);
			}
			else
				return 0;

		}

		public int GetHitterPoints()
		{
			if ( this.HitterStats != null )
			{
				int hitPoints =			this.HitterStats.Hits			* (int)HitterPointValues.Hit;
				int runPoints =			this.HitterStats.Runs			* (int)HitterPointValues.Run;
				int doublePoints =		this.HitterStats.Doubles		* (int)HitterPointValues.Double;
				int triplePoints =		this.HitterStats.Triples		* (int)HitterPointValues.Triple;
				int homeRunPoints =		this.HitterStats.HomeRuns		* (int)HitterPointValues.HomeRun;
				int rbiPoints =			this.HitterStats.RBI			* (int)HitterPointValues.RBI;
				int walkPoints =		this.HitterStats.Walks			* (int)HitterPointValues.Walk;
				int stolenBasePoints =	this.HitterStats.StolenBases	* (int)HitterPointValues.StolenBase;
				int strikeoutPoints =	this.HitterStats.Strikeouts		* (int)HitterPointValues.Strikeout;
				int sacrificePoints =	this.HitterStats.Sacrifices;

				return (hitPoints
						+ runPoints
						+ doublePoints
						+ triplePoints
						+ homeRunPoints
						+ rbiPoints
						+ walkPoints
						+ stolenBasePoints
						+ sacrificePoints
						+ strikeoutPoints);
			}
			else
				return 0;

		}
	}

	
}
