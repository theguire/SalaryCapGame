using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewModels
{
    public class LeagueIndexModel
    {
        public IEnumerable<LeagueIndexListingModel> Leagues { get; set; }

    }
}
