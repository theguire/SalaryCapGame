using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.WebViewModels
{
    public class FranchiseModel
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int LeagueId { get; set; }
    }
}
