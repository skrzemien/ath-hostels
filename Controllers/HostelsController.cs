using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ath_hostels.Data;
using ath_hostels.Models;

namespace ath_hostels.Controllers
{
    public class HostelsController : Controller
    {
        private readonly ath_hostelsContext _context;

        public HostelsController(ath_hostelsContext context)
        {
            _context = context;
        }

        // GET: Hostels
        public async Task<IActionResult> Index()
        {
              return _context.Hostel != null ? 
                          View(await _context.Hostel.ToListAsync()) :
                          Problem("Entity set 'ath_hostelsContext.Hostel'  is null.");
        }

        // GET: Hostels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hostel == null)
            {
                return NotFound();
            }

            var hostel = await _context.Hostel
                .FirstOrDefaultAsync(m => m.HostelId == id);
            if (hostel == null)
            {
                return NotFound();
            }

            return View(hostel);
        }

        // GET: Hostels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hostels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HostelId,Name,Description,Address")] Hostel hostel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hostel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hostel);
        }

        // GET: Hostels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hostel == null)
            {
                return NotFound();
            }

            var hostel = await _context.Hostel.FindAsync(id);
            if (hostel == null)
            {
                return NotFound();
            }
            return View(hostel);
        }

        // POST: Hostels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HostelId,Name,Description,Address")] Hostel hostel)
        {
            if (id != hostel.HostelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hostel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostelExists(hostel.HostelId))
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
            return View(hostel);
        }

        // GET: Hostels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hostel == null)
            {
                return NotFound();
            }

            var hostel = await _context.Hostel
                .FirstOrDefaultAsync(m => m.HostelId == id);
            if (hostel == null)
            {
                return NotFound();
            }

            return View(hostel);
        }

        // POST: Hostels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hostel == null)
            {
                return Problem("Entity set 'ath_hostelsContext.Hostel'  is null.");
            }
            var hostel = await _context.Hostel.FindAsync(id);
            if (hostel != null)
            {
                _context.Hostel.Remove(hostel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostelExists(int id)
        {
          return (_context.Hostel?.Any(e => e.HostelId == id)).GetValueOrDefault();
        }
    }
}
