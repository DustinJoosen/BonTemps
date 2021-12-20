using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Controllers
{
	[Authorize(Roles = "Employee")]
	public class TafelsController : Controller
	{

		private ApplicationDbContext _context;

		public TafelsController(ApplicationDbContext context)
		{
			this._context = context;
		}


		public async Task<IActionResult> Index()
		{
			var reserveringen = await _context.Reserveringen
				.Include(s => s.Klant)
				.Where(s => s.Datum == DateTime.Today)
				.OrderBy(s => s.Tafel)
				.ToListAsync();

			return View(reserveringen);
		}

		public async Task<IActionResult> Factuur(int id)
		{
			var reservering = await _context.Reserveringen
				.Include(s => s.Klant)
				.Include(s => s.BestelRegels).ThenInclude(s => s.Drank)
				.Include(s => s.ReserveringMenus).ThenInclude(s => s.Menu)
				.SingleOrDefaultAsync(s => s.Id == id);

			if(reservering == null)
			{
				return NotFound();
			}

			return View(reservering);
		}

		public async Task<IActionResult> Bestellingen(int id)
		{
			var reservering = await _context.Reserveringen
				.Include(s => s.Klant)
				.Include(s => s.BestelRegels).ThenInclude(s => s.Drank)
				.SingleOrDefaultAsync(s => s.Id == id);

			if (reservering == null)
			{
				return NotFound();
			}

			//get all dranksoorten, including the drank
			var dranksoorten = await _context.DrankSoorten
				.Include(s => s.Dranken)
				.OrderBy(s => s.Soort)//.ThenBy(s => s.Dranken.Select(s => s.Naam))
				.ToListAsync();

			//order the dranken by name
			foreach(var dranksoort in dranksoorten)
			{
				dranksoort.Dranken = dranksoort.Dranken.OrderBy(s => s.Naam).ToList();
			}

			return View(new ReserveringDrankSoortenViewModel { 
				Reservering = reservering, 
				DrankSoorten = dranksoorten
			});
		}

		public async Task<IActionResult> addDrink(int reserveringid, int drankid)
		{
			//get the reservering and drank, and check their value
			var reservering = await _context.Reserveringen
				.Include(s => s.BestelRegels).ThenInclude(s => s.Drank)
				.SingleOrDefaultAsync(s => s.Id == reserveringid);

			var drank = await _context.Dranken
				.FindAsync(drankid);

			if(reservering == null || drank == null)
			{
				return NotFound();
			}

			//if this drank is already added, add to the aantal
			if(reservering.BestelRegels.Select(s => s.Drank).Contains(drank))
			{
				var bestelregel = reservering.BestelRegels.SingleOrDefault(s => s.Drank == drank);
				bestelregel.Aantal++;
			}
			//otherwise, add it to the reservering
			else
			{
				reservering.BestelRegels.Add(new BestelRegel
				{
					DrankId = drankid,
					ReserveringId = reserveringid,
					Aantal = 1
				});
			}

			//save everything and return
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Bestellingen), new { Id = reserveringid });
		}

		public async Task<IActionResult> removeDrink(int reserveringid, int drankid)
		{
			//get the reservering and drank, and check their value
			var reservering = await _context.Reserveringen
				.Include(s => s.BestelRegels).ThenInclude(s => s.Drank)
				.SingleOrDefaultAsync(s => s.Id == reserveringid);

			var drank = await _context.Dranken
				.FindAsync(drankid);

			if (reservering == null || drank == null)
			{
				return NotFound();
			}

			//get the bestelregel and remove it
			var bestelregel = reservering.BestelRegels
				.SingleOrDefault(s => s.DrankId == drank.Id);

			_context.BestelRegels.Remove(bestelregel);

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Bestellingen), new { Id = reserveringid });
		}
	}
}
