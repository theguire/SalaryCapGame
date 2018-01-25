using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.WebViewModels
{
    public class SelectLeagueModel
    {
        public IEnumerable<SelectListItem> Leagues { get; set; }
        public int SelectedLeagueId { get; set; }
    }
}
