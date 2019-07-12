using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwqafTest.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AwqafTest.Models;
using AwqafTest.Models.ViewModels;

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

            var viewModel = new List<FiscalYearViewModel>();

            foreach (var fiscalYear in fiscalYears)
            {
                viewModel.Add(new FiscalYearViewModel
                {
                    FiscalYearId = fiscalYear.FiscalYearId,
                    YearDescription = fiscalYear.YearDescription,
                    StartDate = fiscalYear.StartDate,
                    EndDate = fiscalYear.EndDate,
                    IsCurrent = fiscalYear.IsCurrent > 0,
                    IsOpen =  fiscalYear.IsOpen > 0
                });
            }

            return View(viewModel);
        }
        
        // GET: FiscalYears/Create
        public IActionResult Create()
        {
            // Set NextId to the current maximum value of FISCAL_YEAR_ID + 1
            TempData["NextId"] = _awqafData.GetMaxFiscalYearId() + 1;

            return View();
        }

        // POST: FiscalYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FiscalYearViewModel viewModel)
        {
            // Check to see if FISCAL_YEAR_ID already exists
            if (_awqafData.GetFiscalYearById(viewModel.FiscalYearId) != null)
                ModelState.AddModelError("FiscalYearId", "Specified ID already exists.");

            // Check to see if EndDate is after StartDate
            if (viewModel.StartDate >= viewModel.EndDate)
                ModelState.AddModelError("EndDate", "The End Date must be after the Start Date.");

            if (ModelState.IsValid)
            {
                var fiscalYear = new FiscalYear
                {
                    FiscalYearId = viewModel.FiscalYearId,
                    YearDescription = viewModel.YearDescription,
                    StartDate = viewModel.StartDate,
                    EndDate = viewModel.EndDate,
                    IsCurrent = viewModel.IsCurrent ? (byte)1 : (byte)0,
                    IsOpen = viewModel.IsOpen ? (byte)1 : (byte)0,
                };

                _awqafData.AddFiscalYear(fiscalYear);
                _awqafData.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
    }
}
