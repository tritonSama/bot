using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iBot.Models;
using iBot.Models.IbotDevelopment;

namespace iBot.Controllers.IbotDevelopmentController
{
    public class ActiveRanLoadsController : Controller
    {
        private readonly IbotDevelopmentContext _context;

        public ActiveRanLoadsController(IbotDevelopmentContext context)
        {
            _context = context;
        }

        // GET: ActiveRanLoads
        public async Task<IActionResult> Index()
        {
              return View(await _context.ActiveRanLoads.ToListAsync());
        }

        // GET: ActiveRanLoads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ActiveRanLoads == null)
            {
                return NotFound();
            }

            var activeRanLoad = await _context.ActiveRanLoads
                .FirstOrDefaultAsync(m => m.Projectcode == id);
            if (activeRanLoad == null)
            {
                return NotFound();
            }

            return View(activeRanLoad);
        }

        // GET: ActiveRanLoads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActiveRanLoads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ran,Customer,TechPoc,WbsElement,Fund,Labor,Travel,Procurement,Active,Projectcode")] ActiveRanLoad activeRanLoad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activeRanLoad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activeRanLoad);
        }

        // GET: ActiveRanLoads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ActiveRanLoads == null)
            {
                return NotFound();
            }

            var activeRanLoad = await _context.ActiveRanLoads.FindAsync(id);
            if (activeRanLoad == null)
            {
                return NotFound();
            }
            return View(activeRanLoad);
        }

        // POST: ActiveRanLoads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Ran,Customer,TechPoc,WbsElement,Fund,Labor,Travel,Procurement,Active,Projectcode")] ActiveRanLoad activeRanLoad)
        {
            if (id != activeRanLoad.Projectcode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeRanLoad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiveRanLoadExists(activeRanLoad.Projectcode))
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
            return View(activeRanLoad);
        }

        // GET: ActiveRanLoads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ActiveRanLoads == null)
            {
                return NotFound();
            }

            var activeRanLoad = await _context.ActiveRanLoads
                .FirstOrDefaultAsync(m => m.Projectcode == id);
            if (activeRanLoad == null)
            {
                return NotFound();
            }

            return View(activeRanLoad);
        }

        // POST: ActiveRanLoads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ActiveRanLoads == null)
            {
                return Problem("Entity set 'IbotDevelopmentContext.ActiveRanLoads'  is null.");
            }
            var activeRanLoad = await _context.ActiveRanLoads.FindAsync(id);
            if (activeRanLoad != null)
            {
                _context.ActiveRanLoads.Remove(activeRanLoad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiveRanLoadExists(string id)
        {
          return _context.ActiveRanLoads.Any(e => e.Projectcode == id);
        }
    }
}
