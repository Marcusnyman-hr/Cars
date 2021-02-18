using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cars1._0.Data;
using Cars_mn.Models;
using Cars_mn.Data;
using Microsoft.Extensions.Hosting;

namespace Cars_mn.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarContext _context;

        public CarsController(CarContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var carContext = _context.Cars.Include(c => c.Dealer).Include(c => c.EngineType).Include(c => c.Manufacturer);
            return View(await carContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Dealer)
                .Include(c => c.EngineType)
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["DealerId"] = new SelectList(_context.Dealers, "Id", "Name");
            ViewData["EngineTypeId"] = new SelectList(_context.EngineTypes, "Id", "Fuel");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "ManufacturerName");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManufacturerId,Model,EngineTypeId,Year,Price,DealerId")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DealerId"] = new SelectList(_context.Dealers, "Id", "Name", car.DealerId);
            ViewData["EngineTypeId"] = new SelectList(_context.EngineTypes, "Id", "Id", car.EngineTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "ManufacturerName", car.ManufacturerId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["DealerId"] = new SelectList(_context.Dealers, "Id", "Name", car.DealerId);
            ViewData["EngineTypeId"] = new SelectList(_context.EngineTypes, "Id", "Id", car.EngineTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "ManufacturerName", car.ManufacturerId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManufacturerId,Model,EngineTypeId,Year,Price,DealerId")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            ViewData["DealerId"] = new SelectList(_context.Dealers, "Id", "Name", car.DealerId);
            ViewData["EngineTypeId"] = new SelectList(_context.EngineTypes, "Id", "Id", car.EngineTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "ManufacturerName", car.ManufacturerId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Dealer)
                .Include(c => c.EngineType)
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
        public async Task<IActionResult> LoadJson()
        {
          CarSeeder.Seed(_context);
          return View();
        }
  }
}
