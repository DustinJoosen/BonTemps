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
	public class MenuGerechtenViewComponent : ViewComponent
	{

		private ApplicationDbContext _context;
		public MenuGerechtenViewComponent(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var menu = await _context.Menus
				.Include(s => s.MenuGerechten).ThenInclude(s => s.Gerecht)
				.SingleOrDefaultAsync(s => s.Id == id);


			ViewData["gerechtId"] = new SelectList(_context.Gerechten, "Id", "Naam");
			return View(menu);
		} 
	}
}

