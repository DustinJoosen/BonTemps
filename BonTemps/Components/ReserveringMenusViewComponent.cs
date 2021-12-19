using BonTemps.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Components
{
	public class ReserveringMenusViewComponent : ViewComponent
	{

		private ApplicationDbContext _context;
		public ReserveringMenusViewComponent(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var reservering = await _context.Reserveringen
				.Include(s => s.ReserveringMenus).ThenInclude(s => s.Menu)
				.SingleOrDefaultAsync(s => s.Id == id);

			ViewData["menuId"] = new SelectList(_context.Menus, "Id", "Naam");
			return View(reservering);
		} 
	}
}

