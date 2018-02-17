using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewModels
{
    public class FranchiseMenuModel
    {
        public int OwnerId { get; set; }
        public string FullName { get; set; }
        public IEnumerable<Franchise> Franchises { get; set; }
        public IEnumerable<League> Leagues { get; set; }
    }
}
