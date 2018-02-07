
using SalaryCapData.Models;
using System.Collections.Generic;

namespace SalaryCapGame.ViewModels
{
    public class FranchiseIndexListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public int OwnerId { get; set; }
        public int LeagueId { get; set; }

        public League League { get; set; }
        public Owner Owner { get; set; }

        public long Points { get; set; }
        public decimal Value { get; set; }
        public int NumberOfTrades { get; set; }

    }
}
