using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class MenuSoort
	{
		public int Id { get; set; }

		[Required]
		[StringLength(80)]
		public string Soort { get; set; }
	}
}
