using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.Models
{
    public class PlayerAssignmentDate
    {
        public int Id { get; set; }

        public DateTime DatePlayerDrafted { get; set; }
        public DateTime DatePlayerDropped { get; set; }

        //public int PlayerAssignentId { get; set; }
        //public PlayerAssignment PlayerAssignment { get; set; }
    }
}
