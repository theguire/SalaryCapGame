using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models.PlayerSalary
{

    public class Rootobject
    {
        public Playersalary[] playersalary { get; set; }
    }

    public class Playersalary
    {
        public string Player { get; set; }
        public object Position { get; set; }
        public float? MLS { get; set; }
        public decimal? Salary { get; set; }
    }

}
