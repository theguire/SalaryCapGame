using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryCapData.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Column( "FirstName" )]
        [Display( Name = "First Name" )]
        [Required]
        [RegularExpression( @"^[A-Z]+[a-zA-Z''-'\s]*$" )]
        [StringLength( 50, MinimumLength = 1,
                    ErrorMessage = "First name cannot be longer than 50 characters." )]
        public string FirstName { get; set; }

        [Required]
        [Display( Name = "Last Name" )]
        [StringLength( 50, MinimumLength = 1,
                    ErrorMessage = "Last name cannot be longer than 50 characters." )]
        [RegularExpression( @"^[A-Z]+[a-zA-Z''-'\s]*$" )]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public virtual IEnumerable<Franchise> Franchises { get; set; }
        public virtual IEnumerable<League> Leagues { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
