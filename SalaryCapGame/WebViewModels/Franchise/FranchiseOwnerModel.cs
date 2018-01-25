using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.WebViewModels
{
    public class FranchiseOwnerModel
    {
        FranchiseModel FranchiseModel { get; set; }
        int OwnerId { get; set; }
    }
}
