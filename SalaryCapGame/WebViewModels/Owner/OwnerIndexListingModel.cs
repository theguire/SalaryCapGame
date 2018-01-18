using System.Collections.Generic;
using SalaryCapData.Models;

namespace SalaryCapGame.WebViewModels
{
    public class OwnerIndexListingModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        //public IEnumerable<Owner>Owners { get; set; }
        //public IEnumerable<League>Leagues { get; set; }
        public IEnumerable<Franchise> Franchises { get; set; }

    }

    //public class Franchise
    //{
    //    public string Name;
    //    public string League;
    //}
}
