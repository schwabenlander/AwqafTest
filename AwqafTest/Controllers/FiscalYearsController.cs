using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwqafTest.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AwqafTest.Models;

namespace AwqafTest.Controllers
{
    public class FiscalYearsController : Controller
    {
        private readonly AwqafContext _context;

        public FiscalYearsController(AwqafContext context)
        {
            _context = context;
        }

        // GET: FiscalYears
        public async Task<IActionResult> Index()
        {
            return View(await _context.FiscalYears.ToListAsync());
        }

        // GET: FiscalYears/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiscalYears = await _context.FiscalYears
                .FirstOrDefaultAsync(m => m.FiscalYearId == id);
            if (fiscalYears == null)
            {
                return NotFound();
            }

            return View(fiscalYears);
        }

        // GET: FiscalYears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FiscalYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiscalYearId,YearDescription,StartDate,EndDate,IsCurrent,IsOpen")] FiscalYears fiscalYears)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fiscalYears);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fiscalYears);
        }

        // GET: FiscalYears/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiscalYears = await _context.FiscalYears.FindAsync(id);
            if (fiscalYears == null)
            {
                return NotFound();
            }
            return View(fiscalYears);
        }

        // POST: FiscalYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("FiscalYearId,YearDescription,StartDate,EndDate,IsCurrent,IsOpen")] FiscalYears fiscalYears)
        {
            if (id != fiscalYears.FiscalYearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fiscalYears);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiscalYearsExists(fiscalYears.FiscalYearId))
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
            return View(fiscalYears);
        }

        // GET: FiscalYears/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiscalYears = await _context.FiscalYears
                .FirstOrDefaultAsync(m => m.FiscalYearId == id);
            if (fiscalYears == null)
            {
                return NotFound();
            }

            return View(fiscalYears);
        }

        // POST: FiscalYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var fiscalYears = await _context.FiscalYears.FindAsync(id);
            _context.FiscalYears.Remove(fiscalYears);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiscalYearsExists(byte id)
        {
            return _context.FiscalYears.Any(e => e.FiscalYearId == id);
        }
    }
}
