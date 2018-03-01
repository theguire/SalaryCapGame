using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalaryCapData.Models
{
    public class Player
    {
        [DatabaseGenerated( DatabaseGeneratedOption.None )]
        public int Id { get; set; }
        //public string PlayerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public bool IsRookie { get; set; }
        public string Position { get; set; }
        public decimal InitialValue { get; set; }
		public int TotalPoints { get; set; }
		//public decimal CurrentValue { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
		public HitterStats HitterStats { get; set; }
        public PitcherStats PictherStats { get; set; }
        //public IEnumerable<PlayerPosition> PlayerPositions { get; set; }
    }
}
