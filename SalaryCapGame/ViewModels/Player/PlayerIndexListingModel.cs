using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewModels
{
    public class PlayerIndexListingModel
    {
        public int Id { get; set; }
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public Team Team { get; set; }
        public string Position { get; set; }
    }
}
