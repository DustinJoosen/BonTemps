using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class ReserveringDrankSoortenViewModel
	{
		public Reservering Reservering { get; set; }
		public List<DrankSoort> DrankSoorten { get; set; }
	}
}
