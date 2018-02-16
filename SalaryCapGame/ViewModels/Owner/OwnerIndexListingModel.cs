using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalaryCapData.Models;

namespace SalaryCapGame.ViewModels
{
    public class OwnerIndexListingModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display( Name = "Image Url" )]
        public string ImageUrl { get; set; }

        [Display( Name = "Full Name" )]
        string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public IEnumerable<Franchise> Franchises { get; set; }
        public IEnumerable <League> Leagues { get; set; }

    }
}
