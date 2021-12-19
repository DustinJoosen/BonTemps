using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Authorization;

namespace BonTemps.Controllers
{
    [Authorize(Roles = "Employee")]
    public class GerechtenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GerechtenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gerechten
        public async Task<IActionResult> Index()
        {
            var gerechten = await _context.Gerechten
                .Include(g => g.GerechtSoort)
                .OrderBy(s => s.Naam).ThenBy(s => s.GerechtSoortId)
                .ToListAsync();

            return View(gerechten);
        }

        // GET: Gerechten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerecht = await _context.Gerechten
                .Include(g => g.GerechtSoort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerecht == null)
            {
                return NotFound();
            }

            return View(gerecht);
        }

        // GET: Gerechten/Create
        public IActionResult Create()
        {
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoorten, "Id", "Soort");
            return View();
        }

        // POST: Gerechten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GerechtSoortId,Naam")] Gerecht gerecht)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerecht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoorten, "Id", "Soort", gerecht.GerechtSoortId);
            return View(gerecht);
        }

        // GET: Gerechten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerecht = await _context.Gerechten.FindAsync(id);
            if (gerecht == null)
            {
                return NotFound();
            }
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoorten, "Id", "Soort", gerecht.GerechtSoortId);
            return View(gerecht);
        }

        // POST: Gerechten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GerechtSoortId,Naam")] Gerecht gerecht)
        {
            if (id != gerecht.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerecht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerechtExists(gerecht.Id))
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
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoorten, "Id", "Soort", gerecht.GerechtSoortId);
            return View(gerecht);
        }

        // GET: Gerechten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerecht = await _context.Gerechten
                .Include(g => g.GerechtSoort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerecht == null)
            {
                return NotFound();
            }

            return View(gerecht);
        }

        // POST: Gerechten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerecht = await _context.Gerechten.FindAsync(id);
            _context.Gerechten.Remove(gerecht);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerechtExists(int id)
        {
            return _context.Gerechten.Any(e => e.Id == id);
        }
    }
}
