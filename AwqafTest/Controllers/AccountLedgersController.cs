using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AwqafTest.Database;
using AwqafTest.Models;
using AwqafTest.Models.ViewModels;

namespace AwqafTest.Controllers
{
    public class AccountLedgersController : Controller
    {
        private readonly IAccountLedgerDataService _accountLedgerData;
        private readonly IAccountDataService _accountDataService;
        private readonly IFiscalYearDataService _fiscalYearDataService;

        public AccountLedgersController(IAccountLedgerDataService accountLedgerData, 
                                        IAccountDataService accountDataService, 
                                        IFiscalYearDataService fiscalYearDataService)
        {
            _accountLedgerData = accountLedgerData;
            _accountDataService = accountDataService;
            _fiscalYearDataService = fiscalYearDataService;
        }

        // GET: AccountLedgers
        public IActionResult Index()
        {
            // TODO: Add paging of Account Ledgers
            var accountLedgers = _accountLedgerData.GetAccountLedgers().Take(100);
            var viewModel = new List<AccountLedgerViewModel>();

            foreach (var accountLedger in accountLedgers)
            {
                viewModel.Add(new AccountLedgerViewModel
                {
                    AccountId = accountLedger.AccountId,
                    FiscalYearId = accountLedger.FiscalYearId,
                    LedgerNo = accountLedger.LedgerNo,
                    Ledger = accountLedger.Ledger,
                    SystemDate = accountLedger.SystemDate,
                    UserId = accountLedger.UserId,
                    Remarks = accountLedger.Remarks,
                    Account = accountLedger.Account,
                    FiscalYear = accountLedger.FiscalYear
                });
            }

            return View(viewModel);
        }

        // GET: AccountLedgers/Create
        public IActionResult Create()
        {
            throw new NotImplementedException();

//            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountNumber");
//            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "YearDescription");
//            return View();
        }

        // POST: AccountLedgers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiscalYearId,AccountId,LedgerNo,Ledger,SystemDate,Remarks,UserId")] AccountLedger accountLedger)
        {
            throw new NotImplementedException();

//            if (ModelState.IsValid)
//            {
//                _context.Add(accountLedger);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountNumber", accountLedger.AccountId);
//            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "YearDescription", accountLedger.FiscalYearId);
//            return View(accountLedger);
        }
    }
}
