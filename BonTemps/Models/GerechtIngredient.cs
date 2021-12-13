using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class GerechtIngredient
	{
		[Required]
		public int GerechtId { get; set; }
		public Gerecht Gerecht { get; set; }

		[Required]
		public int IngredientId { get; set; }
		public Ingredient Ingredient { get; set; }

		[Required]
		public int Aantal { get; set; }

	}
}
