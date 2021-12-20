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

		public double TotalPrice()
		{
			var menu_total_price = ReserveringMenus.Select(s => s.Menu.Prijs * s.Aantal).Sum();
			var drank_total_price = BestelRegels.Select(s => s.Drank.Prijs * s.Aantal).Sum();

			//for some reason price of a drank is double instead of decimal. Too late to fix it now...
			return Convert.ToDouble(menu_total_price) + drank_total_price;
		}
	}
}
