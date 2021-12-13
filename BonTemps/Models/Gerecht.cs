using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class Gerecht
	{
		public int Id { get; set; }
		
		[Required]
		public int GerechtSoortId { get; set; }
		public GerechtSoort GerechtSoort { get; set; }
		
		[Required]
		[StringLength(80)]
		public string Naam { get; set; }

		public virtual ICollection<GerechtIngredient> GerechtIngredienten { get; set; }
		public virtual ICollection<MenuGerecht> MenuGerechten { get; set; }
	}
}
