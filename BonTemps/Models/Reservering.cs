using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class Reservering
	{
		public int Id { get; set; }

		[Required]
		public DateTime Datum { get; set; }
		
		[Required]
		public DateTime Tijd { get; set; }

		[Required]
		public int KlantId { get; set; }
		public Klant Klant { get; set; }

		[Required]
		public int Tafel { get; set; }

		public virtual ICollection<BestelRegel> BestelRegels { get; set; }
		public virtual ICollection<ReserveringMenu> ReserveringMenus { get; set; }
	}
}
