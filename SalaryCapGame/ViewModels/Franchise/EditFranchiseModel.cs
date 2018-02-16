using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewModels
{
    public class EditFranchiseModel
    {
        public int OwnerId { get; set; }
        [Required]
        [Display( Name = "Franchise Name")]
        [MaxLength( 50 )]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
