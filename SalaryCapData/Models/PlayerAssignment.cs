using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalaryCapData.Models
{
	public class PlayerAssignment
	{
		public int Id { get; set; }
		[Required]
		public int FranchiseId { get; set; }
		[Required]
		public int PlayerId { get; set; }
		//       [Required]
		//public PlayerPosition PlayerPosition { get; set; }
		public int PlayerPosition { get; set; }
		[Required]
		public DateTime DateDrafted { get; set; }
		public DateTime DateDropped { get; set; }
	}
}
