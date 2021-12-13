using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class BestelRegel
	{
		[Required]
		public int ReserveringId { get; set; }
		public Reservering Reservering { get; set; }

		[Required]
		public int DrankId { get; set; }
		public Drank Drank { get; set; }

		[Required]
		public int Aantal { get; set; }
	}
}
