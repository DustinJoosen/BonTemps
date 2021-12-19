using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BonTemps.Controllers
{
    public class ReserveringenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public ReserveringenController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reserveringen
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Index()
        {
            var reserveringen = await _context.Reserveringen
                .OrderBy(s => s.Datum).ThenBy(s => s.Tijd)
                .Include(s => s.Klant)
                .ToListAsync();

            return View(reserveringen);
        }

        // GET: Reserveringen/Details/5
        [Authorize(Roles = "Customer, Employee")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reserveringen
                .Include(r => r.Klant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // GET: Reserveringen/Create
        [Authorize(Roles = "Customer, Employee")]
        public IActionResult Create()
        {
            ViewData["KlantId"] = new SelectList(_context.Klanten, "Id", "Naam");
            return View();
        }

        // POST: Reserveringen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer, Employee")]
        public async Task<IActionResult> Create([Bind("Id,Datum,Tijd,KlantId,Tafel")] Reservering reservering)
        {
			if (User.IsInRole("Customer"))
			{
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var klant = await _context.Klanten.SingleOrDefaultAsync(s => s.UserId == user.Id);
                
                if(klant== null)
				{
                    return NotFound();
				}

                reservering.KlantId = klant.Id;

			}

            _context.Add(reservering);
            await _context.SaveChangesAsync();

			if (User.IsInRole("Customer"))
			{
                return RedirectToAction(nameof(Details), new { Id = reservering.Id });
			}

            return RedirectToAction(nameof(Index));
        }

        // GET: Reserveringen/Edit/5
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reserveringen
                .Include(s => s.Klant)
                .SingleOrDefaultAsync(s => s.Id == id);
            if (reservering == null)
            {
                return NotFound();
            }
            ViewData["KlantId"] = new SelectList(_context.Klanten, "Id", "Naam", reservering.KlantId);
            return View(reservering);
        }

        // POST: Reserveringen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,Tijd,KlantId")] Reservering reservering)
        {
            if (id != reservering.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveringExists(reservering.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlantId"] = new SelectList(_context.Klanten, "Id", "Naam", reservering.KlantId);
            return View(reservering);
        }

        // GET: Reserveringen/Delete/5
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reserveringen
                .Include(r => r.Klant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // POST: Reserveringen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservering = await _context.Reserveringen.FindAsync(id);
            _context.Reserveringen.Remove(reservering);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddReserveringMenu(int id, int menuId, int aantal)
        {
            //retrieve the reservering and menu based on the id's
            var reservering = await _context.Reserveringen
                .Include(s => s.ReserveringMenus).ThenInclude(s => s.Menu)
                .SingleOrDefaultAsync(s => s.Id == id);

            var menu = await _context.Menus.FindAsync(menuId);

            if (menu == null || reservering == null)
            {
                return NotFound();
            }

            //if the reservering already has the menu, return. Otherwise add it
            if (reservering.ReserveringMenus.Select(s => s.Menu).Contains(menu))
            {
                var reserveringmenu = reservering.ReserveringMenus.SingleOrDefault(s => s.MenuId == menuId);
                reserveringmenu.Aantal += aantal;

                if(reserveringmenu.Aantal <= 0)
				{
                    _context.ReserveringMenus.Remove(reserveringmenu);
				}

            }
            else
            {
                reservering.ReserveringMenus.Add(new ReserveringMenu
                {
                    ReserveringId = reservering.Id,
                    MenuId = menu.Id,
                    Aantal = aantal
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Id = id });

        }

        public async Task<IActionResult> RemoveReserveringMenu(int reserveringid, int menuid)
        {
            //retrieve the reservering and menu based on the id's
            var reservering = await _context.Reserveringen
                .Include(s => s.ReserveringMenus).ThenInclude(s => s.Menu)
                .SingleOrDefaultAsync(s => s.Id == reserveringid);

            var menu = await _context.Menus.FindAsync(menuid);

            if (menu == null || reservering == null)
            {
                return NotFound();
            }

            var reserveringMenu = reservering.ReserveringMenus.SingleOrDefault(s => s.MenuId == menuid && s.ReserveringId== reserveringid);

            //if the menu has the gerecht, remove it
            if (reserveringMenu != null)
            {
                reservering.ReserveringMenus.Remove(reserveringMenu);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { Id = reserveringid });
        }

        private bool ReserveringExists(int id)
        {
            return _context.Reserveringen.Any(e => e.Id == id);
        }
    }
}
