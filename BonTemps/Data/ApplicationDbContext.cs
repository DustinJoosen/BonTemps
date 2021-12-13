using BonTemps.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BonTemps.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Allergie> Allergien { get; set; }
		public DbSet<BestelRegel> BestelRegels{ get; set; }
		public DbSet<Drank> Dranken{ get; set; }
		public DbSet<DrankSoort> DrankSoorten{ get; set; }
		public DbSet<Gerecht> Gerechten{ get; set; }
		public DbSet<GerechtIngredient> GerechtIngredienten{ get; set; }
		public DbSet<GerechtSoort> GerechtSoorten{ get; set; }
		public DbSet<Ingredient> Ingredienten { get; set; }
		public DbSet<Klant> Klanten{ get; set; }
		public DbSet<Menu> Menus{ get; set; }
		public DbSet<MenuGerecht> MenuGerechten { get; set; }
		public DbSet<MenuSoort> MenuSoorten { get; set; }
		public DbSet<Reservering> Reserveringen{ get; set; }
		public DbSet<ReserveringMenu> ReserveringMenus { get; set; }
		public DbSet<Vegetarisch> Vegetarisch { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			//configuring the pivot tables
			builder.Entity<BestelRegel>()
				.HasKey(table => new
				{
					table.DrankId,
					table.ReserveringId
				});
			
			builder.Entity<GerechtIngredient>()
				.HasKey(table => new
				{
					table.GerechtId,
					table.IngredientId
				});
			
			builder.Entity<MenuGerecht>()
				.HasKey(table => new
				{
					table.MenuId,
					table.GerechtId
				});
			
			builder.Entity<ReserveringMenu>()
				.HasKey(table => new
				{
					table.MenuId,
					table.ReserveringId
				});

			//configuring unique indexes
			builder.Entity<Allergie>()
				.HasIndex(a => a.Allergeen)
				.IsUnique();

			builder.Entity<Drank>()
				.HasIndex(d => d.Naam)
				.IsUnique();

			builder.Entity<DrankSoort>()
				.HasIndex(d => d.Soort)
				.IsUnique();

			builder.Entity<Gerecht>()
				.HasIndex(g => g.Naam)
				.IsUnique();

			builder.Entity<GerechtSoort>()
				.HasIndex(g => g.Soort)
				.IsUnique();

			builder.Entity<Ingredient>()
				.HasIndex(i => i.Naam)
				.IsUnique();

			builder.Entity<Klant>()
				.HasIndex(k => k.UserId)
				.IsUnique();

			builder.Entity<Klant>()
				.HasIndex(k => k.Naam);

			builder.Entity<Menu>()
				.HasIndex(m => m.Naam)
				.IsUnique();

			builder.Entity<MenuSoort>()
				.HasIndex(m => m.Soort)
				.IsUnique();

			builder.Entity<Vegetarisch>()
				.HasIndex(v => v.Soort)
				.IsUnique();

			//seed the data
			builder.Entity<Allergie>()
				.HasData(
				new Allergie() { Id = 1, Allergeen = "Ei" },
				new Allergie() { Id = 2, Allergeen = "Gluten" },
				new Allergie() { Id = 3, Allergeen = "Melk" },
				new Allergie() { Id = 4, Allergeen = "Sezamzaad" },
				new Allergie() { Id = 5, Allergeen = "Noten" },
				new Allergie() { Id = 6, Allergeen = "Pindas" },
				new Allergie() { Id = 7, Allergeen = "Mosterd" },
				new Allergie() { Id = 8, Allergeen = "Vis" }
				);

			builder.Entity<DrankSoort>()
				.HasData(
				new DrankSoort() { Id = 1, Soort = "Alcohol" },
				new DrankSoort() { Id = 2, Soort = "Frisdrank" },
				new DrankSoort() { Id = 3, Soort = "Kinderdranken" },
				new DrankSoort() { Id = 4, Soort = "Overige" }
				);

			builder.Entity<Vegetarisch>().HasData(
				new Vegetarisch() { Id = 1, Soort = "Vegetarier" },
				new Vegetarisch() { Id = 2, Soort = "Veganist" },
				new Vegetarisch() { Id = 3, Soort = "Flexitarier" },
				new Vegetarisch() { Id = 4, Soort = "Pescotarier" },
				new Vegetarisch() { Id = 5, Soort = "Pollotarier" }
			);

			builder.Entity<GerechtSoort>().HasData(
				new GerechtSoort() { Id = 1, Soort = "Voorgerecht" },
				new GerechtSoort() { Id = 2, Soort = "Hoofdgerecht" },
				new GerechtSoort() { Id = 3, Soort = "Nagerecht" },
				new GerechtSoort() { Id = 4, Soort = "Bijgerecht" },
				new GerechtSoort() { Id = 5, Soort = "Desert" }
			);

			builder.Entity<MenuSoort>().HasData(
				new MenuSoort() { Id = 1, Soort = "Lunch" },
				new MenuSoort() { Id = 2, Soort = "Dinner" }
			);
		}
	}
}
