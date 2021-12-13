using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class Allergie
	{
		public int Id { get; set; }

		[Required]
		[StringLength(80)]
		public string Allergeen { get; set; }
	}
}
