using SalaryCapData.Models;
using System.ComponentModel.DataAnnotations;

namespace SalaryCapGame.ViewModels
{
    public class LeagueListingModel
    {
        public int Id { get; set; }
        [Display( Name = "League" )]
        [MinLength( 5 )]
        [MaxLength( 15 )]
        public string Name { get; set; }

        public int CommissionerId { get; set; }
        public Owner Commissioner { get; set; }

        public int NumberOfFranchises { get; set; }
        public int MaxLeagueSize { get; set; }
        [Display( Name = "Type" )]
        public bool IsPrivate { get; set; }
    }
}
