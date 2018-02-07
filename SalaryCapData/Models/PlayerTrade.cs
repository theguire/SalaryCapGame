using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.Models
{
    public class PlayerTrade
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime TradeDate { get; set; }
        public int Drops { get; set; }
        public int Drafts { get; set; }
    }
}
