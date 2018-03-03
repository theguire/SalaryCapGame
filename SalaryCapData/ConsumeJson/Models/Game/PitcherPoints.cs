using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models.Game
{
    public class PitcherPoints
    {
		public enum PitcherPointValues
		{
			SO = 5,
			Win = 10,
			Loss = -10,
			Hits = -1,
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
