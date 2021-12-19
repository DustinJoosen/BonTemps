using BonTemps.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Controllers
{
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
	}
}
