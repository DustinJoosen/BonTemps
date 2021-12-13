using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class MenuGerecht
	{
		[Required]
		public int MenuId { get; set; }
		public Menu Menu { get; set; }

		[Required]
		public int GerechtId { get; set; }
		public Gerecht Gerecht { get; set; }


	}
}
