using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewModels
{
	public class PlayerPositionAssignments
	{
		public PlayerAssignment Pitcher1 { get; set; }
		public PlayerAssignment Pitcher2 { get; set; }
		public PlayerAssignment Pitcher3 { get; set; }
		public PlayerAssignment Pitcher4 { get; set; }
		public PlayerAssignment Catcher { get; set; }
		public PlayerAssignment FirstBase { get; set; }
		public PlayerAssignment SecondBase { get; set; }
		public PlayerAssignment ThirdBase { get; set; }
		public PlayerAssignment Shortstop { get; set; }
		public PlayerAssignment Outfielder1 { get; set; }
		public PlayerAssignment Outfielder2 { get; set; }
		public PlayerAssignment Outfielder4 { get; set; }
		public PlayerAssignment DesignatedHitter { get; set; }
	}
}
