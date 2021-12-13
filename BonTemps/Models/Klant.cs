using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
	public class Klant
	{
		public int Id { get; set; }

		[StringLength(256)]
		public string UserId { get; set; }
		public IdentityUser User { get; set; }

		[Required]
		[StringLength(40)]
		public string Naam { get; set; }

		[StringLength(40)]
		public string Adres { get; set; }

		[StringLength(6)]
		public string PostCode { get; set; }

		[StringLength(25)]
		public string Woonplaats { get; set; }
	}
}
