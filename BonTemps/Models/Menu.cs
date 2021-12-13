using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class Menu
	{
		public int Id { get; set; }

		[Required]
		public int MenuSoortId { get; set; }
		public MenuSoort MenuSoort { get; set; }

		[Required]
		[StringLength(40)]
		public string Naam { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Prijs { get; set; }

		public virtual ICollection<ReserveringMenu> ReserveringMenus { get; set; }
		public virtual ICollection<MenuGerecht> MenuGerechten { get; set; }
	}
}
