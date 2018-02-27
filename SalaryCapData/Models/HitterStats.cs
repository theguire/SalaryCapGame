using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.Models
{
    public class HitterStats
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public bool IsCumulative { get; set; }
        public Player Player { get; set; }
        public DateTime Date { get; set; }
        public int Runs { get; set; }
        public int Hits { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HomeRuns { get; set; }
        public int RBI { get; set; }
        public int Walks { get; set; }
        public int StolenBases { get; set; }
        public int Sacrifices { get; set; }
        public int ExtraBases { get; set; }
        public int TotalBases { get; set; }
    }
}
