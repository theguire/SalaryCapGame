using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.WebViewModels
{
    public class FranchiseDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public int OwnerId { get; set; }
        public int LeagueId { get; set; }

        public League League { get; set; }
        public Owner Owner { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}
