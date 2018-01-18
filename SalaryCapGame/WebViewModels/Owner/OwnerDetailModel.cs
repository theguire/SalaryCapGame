using SalaryCapData.Models;
using System.Collections.Generic;

namespace SalaryCapGame.WebViewModels
{
    public class OwnerDetailModel
    {
        public int OwnerId { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerEmail { get; set; }
        public string ImageUrl { get; set; }
        public string NewFranchiseName { get; set; }

        public IEnumerable<Franchise> Franchises { get; set; }

        //public IEnumerable<League> Leagues { get; set; }
    }
}
