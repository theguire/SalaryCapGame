using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalaryCapData.Models
{
    public class Team
    {
        [ DatabaseGenerated( DatabaseGeneratedOption.None ) ]
        public int Id { get; set; }
        //public string TeamId { get; set; }
        public string City { get; set; }
        public string Name{ get;set;}
        public string Abbrev { get; set; }
    }
}
