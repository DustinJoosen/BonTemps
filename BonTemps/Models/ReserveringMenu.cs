using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class ReserveringMenu
	{
		[Required]
		public int ReserveringId { get; set; }
		public Reservering Reservering { get; set; }

		[Required]
		public int MenuId { get; set; }
		public Menu Menu { get; set; }

		[Required]
		public int Aantal{ get; set; }

	}
}
