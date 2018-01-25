using SalaryCapData.Models;
using System.Collections.Generic;

namespace SalaryCapGame.WebViewModels
{
    public class OwnerDetailModel
    {
        //public int OwnerId { get; set; }
        //public string OwnerLastName { get; set; }
        //public string OwnerFirstName { get; set; }
        //public string OwnerEmail { get; set; }
        //public string ImageUrl { get; set; }
        public EditFranchiseName GetEditFranchiseName { get; set; }
        public OwnerIndexListingModel OwnerIndexListingModel { get; set; }
        public SelectLeagueModel SelectLeague { get; set; }

        public IEnumerable<Franchise> Franchises { get; set; }
        //public string NewFranchiseName { get; internal set; }

        //public IEnumerable<League> Leagues { get; set; }
    }
}
