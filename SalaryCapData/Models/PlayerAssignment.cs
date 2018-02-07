using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalaryCapData.Models
{
    public class PlayerAssignment
    {
        public int Id { get; set; }
        [Required]
        public int FranchiseId { get; set;  }
        [Required]
        public int PlayerId { get; set; }
 //       [Required]
        //public PlayerPosition PlayerPosition { get; set; }
        [Required]
        DateTime DateDrafted { get; set; }
        DateTime DateDropped { get; set; }

     }
}
