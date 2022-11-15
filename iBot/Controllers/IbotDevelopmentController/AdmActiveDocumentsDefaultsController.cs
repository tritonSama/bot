using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iBot.Models.IbotDevelopment;
using iBot.Models;

namespace iBot.Controllers.IbotDevelopmentController
{
    public class AdmActiveDocumentsDefaultsController : Controller
    {
        private readonly IbotDevelopmentContext _context;

        public AdmActiveDocumentsDefaultsController(IbotDevelopmentContext context)
        {
            _context = context;
        }

        // GET: AdmActiveDocumentsDefaults
        public async Task<IActionResult> Index()
        {
              return View(await _context.AdmActiveDocumentsDefaults.ToListAsync());
        }

        // GET: AdmActiveDocumentsDefaults/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AdmActiveDocumentsDefaults == null)
            {
                return NotFound();
            }

            var admActiveDocumentsDefault = await _context.AdmActiveDocumentsDefaults
                .FirstOrDefaultAsync(m => m.DocumentNum == id);
            if (admActiveDocumentsDefault == null)
            {
                return NotFound();
            }

            return View(admActiveDocumentsDefault);
        }

        // GET: AdmActiveDocumentsDefaults/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdmActiveDocumentsDefaults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentNum,Vendor,EndDate")] AdmActiveDocumentsDefault admActiveDocumentsDefault)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admActiveDocumentsDefault);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admActiveDocumentsDefault);
        }

        // GET: AdmActiveDocumentsDefaults/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AdmActiveDocumentsDefaults == null)
            {
                return NotFound();
            }

            var admActiveDocumentsDefault = await _context.AdmActiveDocumentsDefaults.FindAsync(id);
            if (admActiveDocumentsDefault == null)
            {
                return NotFound();
            }
            return View(admActiveDocumentsDefault);
        }

        // POST: AdmActiveDocumentsDefaults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DocumentNum,Vendor,EndDate")] AdmActiveDocumentsDefault admActiveDocumentsDefault)
        {
            if (id != admActiveDocumentsDefault.DocumentNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admActiveDocumentsDefault);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmActiveDocumentsDefaultExists(admActiveDocumentsDefault.DocumentNum))
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
            return View(admActiveDocumentsDefault);
        }

        // GET: AdmActiveDocumentsDefaults/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AdmActiveDocumentsDefaults == null)
            {
                return NotFound();
            }

            var admActiveDocumentsDefault = await _context.AdmActiveDocumentsDefaults
                .FirstOrDefaultAsync(m => m.DocumentNum == id);
            if (admActiveDocumentsDefault == null)
            {
                return NotFound();
            }

            return View(admActiveDocumentsDefault);
        }

        // POST: AdmActiveDocumentsDefaults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AdmActiveDocumentsDefaults == null)
            {
                return Problem("Entity set 'IbotDevelopmentContext.AdmActiveDocumentsDefaults'  is null.");
            }
            var admActiveDocumentsDefault = await _context.AdmActiveDocumentsDefaults.FindAsync(id);
            if (admActiveDocumentsDefault != null)
            {
                _context.AdmActiveDocumentsDefaults.Remove(admActiveDocumentsDefault);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmActiveDocumentsDefaultExists(string id)
        {
          return _context.AdmActiveDocumentsDefaults.Any(e => e.DocumentNum == id);
        }
    }
}
