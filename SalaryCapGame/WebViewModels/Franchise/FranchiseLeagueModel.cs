using SalaryCapData.Models;
using SalaryCapGame.WebViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.WebViewModels
{
    public class FranchiseLeagueModel
    {
        public FranchiseModel FranchiseModel { get; set; }
        public IEnumerable<LeagueIndexListingModel> Leagues { get; set; }
    }
}
