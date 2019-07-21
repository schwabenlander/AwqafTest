using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AwqafTest.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AwqafTest.Models;
using AwqafTest.Models.ViewModels;

namespace AwqafTest.Controllers
{
    public class FiscalYearsController : Controller
    {
        private readonly IFiscalYearDataService _fiscalYearData;
        private readonly IMapper _mapper;

        public FiscalYearsController(IFiscalYearDataService fiscalYearData, 
                                     IMapper mapper)
        {
            _fiscalYearData = fiscalYearData;
            _mapper = mapper;
        }

        // GET: FiscalYears
        public IActionResult Index()
        {
            var fiscalYears = _fiscalYearData.GetFiscalYears();

            var viewModel = fiscalYears.Select(fiscalYear => _mapper.Map<FiscalYearViewModel>(fiscalYear)).ToList();

            return View(viewModel);
        }
        
        // GET: FiscalYears/Create
        public IActionResult Create()
        {
            // Set NextId to the current maximum value of FISCAL_YEAR_ID + 1
            ViewData["NextId"] = _fiscalYearData.GetMaxFiscalYearId() + 1;

            return View();
        }

        // POST: FiscalYears/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FiscalYearViewModel viewModel)
        {
            // Check to see if FISCAL_YEAR_ID already exists
            if (_fiscalYearData.GetFiscalYearById(viewModel.FiscalYearId) != null)
                ModelState.AddModelError("FiscalYearId", $"Fiscal Year ID already exists.");

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

                try
                {
                    _fiscalYearData.AddFiscalYear(fiscalYear);
                    _fiscalYearData.Save();
                }
                catch (Exception e)
                {
                    // TODO: Log this exception
                    ModelState.AddModelError(string.Empty, $"ERROR: Unable to save data. Please review your input and try again.");
                    
                    return View(viewModel);
                }
                
                return RedirectToAction(nameof(Index));
            }

            ViewData["NextId"] = viewModel.FiscalYearId;
            return View(viewModel);
        }
    }
}
