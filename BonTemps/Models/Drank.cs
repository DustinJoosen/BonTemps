using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class Drank
	{
		public int Id { get; set; }
		
		[Required]
		public int DrankSoortId { get; set; }
		public DrankSoort DrankSoort { get; set; }

		[StringLength(80)]
		[Required]
		public string Naam { get; set; }
		
		[DataType(DataType.Currency)]
		public double Prijs { get; set; }

		public virtual ICollection<BestelRegel> BestelRegels { get; set; }

	}
}
