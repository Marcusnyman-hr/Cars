using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cars1._0.Data;
using Cars_mn.Models;

namespace Cars_mn.Controllers
{
    public class DealersController : Controller
    {
        private readonly CarContext _context;

        public DealersController(CarContext context)
        {
            _context = context;
        }

        // GET: Dealers
        public async Task<IActionResult> Index()
        {
            var carContext = _context.Dealers.Include(d => d.City);
            return View(await carContext.ToListAsync());
        }

        // GET: Dealers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealer = await _context.Dealers
                .Include(d => d.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealer == null)
            {
                return NotFound();
            }
            var results = _context.Cars
            .Where(c => c.DealerId == id)
            .ToList();

      return View(dealer);
        }

        // GET: Dealers/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            return View();
        }

        // POST: Dealers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CityId")] Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dealer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", dealer.CityId);
            return View(dealer);
        }

        // GET: Dealers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealer = await _context.Dealers.FindAsync(id);
            if (dealer == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", dealer.CityId);
            return View(dealer);
        }

        // POST: Dealers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CityId")] Dealer dealer)
        {
            if (id != dealer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dealer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealerExists(dealer.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", dealer.CityId);
            return View(dealer);
        }

        // GET: Dealers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealer = await _context.Dealers
                .Include(d => d.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealer == null)
            {
                return NotFound();
            }

            return View(dealer);
        }

        // POST: Dealers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dealer = await _context.Dealers.FindAsync(id);
            _context.Dealers.Remove(dealer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealerExists(int id)
        {
            return _context.Dealers.Any(e => e.Id == id);
        }
    }
}
