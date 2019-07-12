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
        private readonly IAwqafDataService _awqafData;

        public FiscalYearsController(IAwqafDataService awqafData)
        {
            _awqafData = awqafData;
        }

        // GET: FiscalYears
        public IActionResult Index()
        {
            var fiscalYears = _awqafData.GetFiscalYears();

            return View(fiscalYears);
        }

        // GET: FiscalYears/Details/5
        public IActionResult Details(byte id)
        {
            var fiscalYear = _awqafData.GetFiscalYearById(id);

            if (fiscalYear == null)
                return NotFound();

            return View(fiscalYear);
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
        public IActionResult Create([Bind("FiscalYearId,YearDescription,StartDate,EndDate,IsCurrent,IsOpen")] FiscalYear fiscalYear)
        {
            if (ModelState.IsValid)
            {
                _awqafData.AddFiscalYear(fiscalYear);
                _awqafData.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(fiscalYear);
        }

        // GET: FiscalYears/Edit/5
        public IActionResult Edit(byte id)
        {
            var fiscalYear = _awqafData.GetFiscalYearById(id);

            if (fiscalYear == null)
                return NotFound();

            return View(fiscalYear);
        }

        // POST: FiscalYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(byte id, [Bind("FiscalYearId,YearDescription,StartDate,EndDate,IsCurrent,IsOpen")] FiscalYear fiscalYear)
        {
            if (id != fiscalYear.FiscalYearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _awqafData.UpdateFiscalYear(fiscalYear);
                _awqafData.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(fiscalYear);
        }

        // GET: FiscalYears/Delete/5
        public IActionResult Delete(byte id)
        {
            var fiscalYear = _awqafData.GetFiscalYearById(id);

            if (fiscalYear == null)
                return NotFound();

            return View(fiscalYear);
        }

        // POST: FiscalYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(byte id)
        {
            var fiscalYear = _awqafData.GetFiscalYearById(id);

            if (fiscalYear == null)
                return NotFound();

            _awqafData.DeleteFiscalYear(id);
            _awqafData.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
