using SalaryCapData.Models;
using SalaryCapGame.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewModels.Dashboard
{
	public class StatsIndexListModel
	{
		//public int TotalPoints { get; set; }
		public IEnumerable<HitterStats> HitterStats { get; set; }
		public IEnumerable<PitcherStats> PicthterStats { get; set; }
	}
}
