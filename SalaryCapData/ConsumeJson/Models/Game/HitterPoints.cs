using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models.Game
{
    public class HitterPoints
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
    }
}
