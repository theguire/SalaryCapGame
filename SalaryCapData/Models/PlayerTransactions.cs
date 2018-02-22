using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.Models
{
    public class PlayerTransactions
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime TradeDate { get; set; }
        public int DroppedCount { get; set; }
        public int AddedCount { get; set; }
    }
}
