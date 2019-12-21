using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRent.Data;
using CarRent.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarRent.Controllers
{
    public class PassportsController : Controller
    {
        private readonly MyAppDataContext _context;

        public PassportsController(MyAppDataContext context)
        {
            _context = context;
        }

        // GET: Passports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Passports.ToListAsync());
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsValidLevel(string Level)
        {

            if (Levels.Any(Level.Contains))
            {
                return Json(true);
            }
            else
            {
                return Json($"Level {Level} is invalid.");
            }
        }

           public static string[] Levels = new string[]
           {
                "A",
                "A1",
                "B",
                "BE",
                "B1",
                "C",
                "CE",
                "C1",
                "C1E",
                "D",
                "DE",
                "D1",
                "D1E",
                "Tm",
                "Tb",
        
           };
    

    // GET: Passports/Details/5
    public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passport = await _context.Passports
                .FirstOrDefaultAsync(m => m.passportID == id);
            if (passport == null)
            {
                return NotFound();
            }

            return View(passport);
        }

        // GET: Passports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("passportID,No,RegistationDate,Level")] Passport passport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passport);
        }

        // GET: Passports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passport = await _context.Passports.FindAsync(id);
            if (passport == null)
            {
                return NotFound();
            }
            return View(passport);
        }

        // POST: Passports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("passportID,No,RegistationDate,Level")] Passport passport)
        {
            if (id != passport.passportID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassportExists(passport.passportID))
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
            return View(passport);
        }

        // GET: Passports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passport = await _context.Passports
                .FirstOrDefaultAsync(m => m.passportID == id);
            if (passport == null)
            {
                return NotFound();
            }

            return View(passport);
        }

        // POST: Passports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passport = await _context.Passports.FindAsync(id);
            _context.Passports.Remove(passport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassportExists(int id)
        {
            return _context.Passports.Any(e => e.passportID == id);
        }
    }
}
