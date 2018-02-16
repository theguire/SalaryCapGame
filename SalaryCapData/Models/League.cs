﻿

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalaryCapData.Models
{
    public class League
    {
        public int Id { get; set; }

        [Required]
        [StringLength( 50, MinimumLength = 1,
                    ErrorMessage = "League name cannot be longer than 50 characters." )]
        [RegularExpression( @"^[A-Z]+[a-zA-Z''-'\s]*$" )]
        public string Name { get; set; }

        [Required]
        public int CommissionerId { get; set; }
        public Owner Commissioner { get; set; }

        public int MaxNumberFranchises { get; set; }
        public bool IsPrivate { get; set; }

        public int Points { get; set; }
        public decimal Value { get; set; }
        

        public virtual IEnumerable<Franchise> Franchises { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
