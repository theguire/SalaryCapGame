using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalaryCapData.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        public string PlayerName { get; set; }

        public IEnumerable<PlayerAssignment> Franchises { get; set; }
        public IEnumerable<PlayerValue> PlayerValues { get; set; }
        public IEnumerable<PlayerTrade> PlayerTrades { get; set; }

        //public virtual IEnumerable<PlayerPosition> PlayerPositions { get; set; }
    }
}
