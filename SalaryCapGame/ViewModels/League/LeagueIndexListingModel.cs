using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewModels
{
	public class LeagueIndexListingModel
	{
		public LeagueListingModel LeagueListingModel { get; set; }
		public IEnumerable<Franchise> Franchises { get; set; }
	}
}
