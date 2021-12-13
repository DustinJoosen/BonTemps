using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class Ingredient
	{
		public int Id { get; set; }
		
		[Required]
		[StringLength(60)]
		public string Naam { get; set; }
		
		[Required]
		[StringLength(20)]
		public string Eenheid { get; set; }
		
		public int VegetarischId { get; set; }
		public Vegetarisch Vegetarisch { get; set; }

		public int AllergieId { get; set; }
		public Allergie Allergie { get; set; }

		public virtual ICollection<GerechtIngredient> GerechtIngredienten { get; set; }
	}
}
