using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewModels
{
    public class LeagueIndexListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CommissionerId { get; set; }
        public Owner Commissioner { get; set; }

        public IEnumerable<Franchise> Franchises { get; set; }
    }
}
