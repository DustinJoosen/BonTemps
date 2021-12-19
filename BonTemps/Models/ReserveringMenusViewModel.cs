using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class ReserveringMenusViewModel
	{
		public Reservering Reservering{ get; set; }
		public List<Menu> Menus { get; set; }
	}
}
