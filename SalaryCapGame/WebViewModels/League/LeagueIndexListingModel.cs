using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.WebViewModels
{
    public class LeagueIndexListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public int CommissionerId { get; set; }
        public Owner Commissioner { get; set; }
    }
}
