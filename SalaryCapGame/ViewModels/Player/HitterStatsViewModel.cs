using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewModels.Player
{
    public class HitterStatsViewModel
    {
        public int PlayerId { get; set; }

        public int Hits { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HomeRuns { get; set; }
        public int Runs { get; set; }
        public int RBIs { get; set; }
        public int StolenBases { get; set; }
        public int Walks { get; set; }

        public int Strikeouts { get; set; }
        public int Outs { get; set; }
    }
}
