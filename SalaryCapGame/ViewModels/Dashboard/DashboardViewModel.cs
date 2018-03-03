using SalaryCapGame.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewModels
{
    public class DashboardViewModel
    {
        public OwnerIndexListingModel OwnerIndex { get; set; }
        //public PlayerIndexModel PlayerIndexModel { get; set; }
		public StatsIndexListModel PlayerStats { get; set; }
    }
}
