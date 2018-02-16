

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalaryCapData.Models
{
    public class Franchise
    {
        public int Id { get; set; }

        [Required]
        [Display( Name = "Franchise Name" )]
        [StringLength( 50, MinimumLength = 1,
             ErrorMessage = "Franchise name cannot be longer than 50 characters." )]
        [RegularExpression( @"^[A-Z]+[a-zA-Z''-'\s]*$" )]
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public int LeagueId { get; set; }
        public virtual League League { get; set; }

        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public long Points { get; set; }
        public decimal Value { get; set; }
        public int NumberOfTrades { get; set; }

        public IEnumerable<PlayerAssignment> Players { get; set; }

    }
}
