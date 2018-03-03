using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models.Game
{
    public class GamePoints
    {
		public enum HitterPointValues
		{
			Hit = 2,
			Double = 2,
			Triple = 3,
			HomeRun = 4,
			Run = 2,
			RBI = 2,
			Walk = 1,
			Sacrifice = 1,
			StolenBase = 1,
			Strikeout = -2
		};

		public enum PitcherPointValues
		{
			SO = 5,
			Win = 10,
			Loss = -10,
			Hit = -1,
			Save = 5,
			Run = -2,
			Walk = -1,
			Hold = 3,
			InningPitched = 1,
			CompleteGamne = 10,
			Strikeout = 5
		};
	}
}
