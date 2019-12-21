using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRent.Data;
using CarRent.Models;

namespace CarRent.Controllers
{
    public class RentedCarsController : Controller
    {
        private readonly MyAppDataContext _context;

        public RentedCarsController(MyAppDataContext context)
        {
            _context = context;
        }

        // GET: RentedCars
        public async Task<IActionResult> Index()
        {
            var myAppDataContext = _context.RentedCars.Include(r => r.Car).Include(r => r.Employee);
            return View(await myAppDataContext.ToListAsync());
        }

        // GET: RentedCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedCars = await _context.RentedCars
                .Include(r => r.Car)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rentedCars == null)
            {
                return NotFound();
            }

            return View(rentedCars);
        }

        // GET: RentedCars/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "carID", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeID", "Name");
            return View();
        }

        // POST: RentedCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StartTime,EndTime,EmployeeId,CarId")] RentedCars rentedCars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentedCars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "carID", "Name", rentedCars.CarId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeID", "Name", rentedCars.EmployeeId);
            return View(rentedCars);
        }

        // GET: RentedCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedCars = await _context.RentedCars.FindAsync(id);
            if (rentedCars == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "carID", "Name", rentedCars.CarId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeID", "Name", rentedCars.EmployeeId);
            return View(rentedCars);
        }

        // POST: RentedCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StartTime,EndTime,EmployeeId,CarId")] RentedCars rentedCars)
        {
            if (id != rentedCars.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentedCars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentedCarsExists(rentedCars.ID))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "carID", "Name", rentedCars.CarId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeID", "Name", rentedCars.EmployeeId);
            return View(rentedCars);
        }

        // GET: RentedCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedCars = await _context.RentedCars
                .Include(r => r.Car)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rentedCars == null)
            {
                return NotFound();
            }

            return View(rentedCars);
        }

        // POST: RentedCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentedCars = await _context.RentedCars.FindAsync(id);
            _context.RentedCars.Remove(rentedCars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentedCarsExists(int id)
        {
            return _context.RentedCars.Any(e => e.ID == id);
        }
    }
}
