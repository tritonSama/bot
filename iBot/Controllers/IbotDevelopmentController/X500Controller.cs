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
    public class X500Controller : Controller
    {
        private readonly IbotDevelopmentContext _context;

        public X500Controller(IbotDevelopmentContext context)
        {
            _context = context;
        }

        // GET: X500
        public async Task<IActionResult> Index()
        {
              return View(await _context.X500s.ToListAsync());
        }

        // GET: X500/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.X500s == null)
            {
                return NotFound();
            }

            var x500 = await _context.X500s
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (x500 == null)
            {
                return NotFound();
            }

            return View(x500);
        }

        // GET: X500/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: X500/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniqueId,FirstName,LastName,Mi,Phone,Org,Email,MailCode,Building,Room,Employer,EmployerAbbr,Uupic,AgencyId,Center")] X500 x500)
        {
            if (ModelState.IsValid)
            {
                _context.Add(x500);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(x500);
        }

        // GET: X500/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.X500s == null)
            {
                return NotFound();
            }

            var x500 = await _context.X500s.FindAsync(id);
            if (x500 == null)
            {
                return NotFound();
            }
            return View(x500);
        }

        // POST: X500/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UniqueId,FirstName,LastName,Mi,Phone,Org,Email,MailCode,Building,Room,Employer,EmployerAbbr,Uupic,AgencyId,Center")] X500 x500)
        {
            if (id != x500.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(x500);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!X500Exists(x500.UniqueId))
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
            return View(x500);
        }

        // GET: X500/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.X500s == null)
            {
                return NotFound();
            }

            var x500 = await _context.X500s
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (x500 == null)
            {
                return NotFound();
            }

            return View(x500);
        }

        // POST: X500/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.X500s == null)
            {
                return Problem("Entity set 'IbotDevelopmentContext.X500s'  is null.");
            }
            var x500 = await _context.X500s.FindAsync(id);
            if (x500 != null)
            {
                _context.X500s.Remove(x500);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool X500Exists(string id)
        {
          return _context.X500s.Any(e => e.UniqueId == id);
        }
    }
}
