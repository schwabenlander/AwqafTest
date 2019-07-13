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
        private readonly IAccountDataService _accountData;
        private readonly IFiscalYearDataService _fiscalYearData;

        public AccountLedgersController(IAccountLedgerDataService accountLedgerData, 
                                        IAccountDataService accountData, 
                                        IFiscalYearDataService fiscalYearData)
        {
            _accountLedgerData = accountLedgerData;
            _accountData = accountData;
            _fiscalYearData = fiscalYearData;
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
                    Account = accountLedger.Account.AccountNumber,
                    FiscalYear = accountLedger.FiscalYear.YearDescription
                });
            }

            return View(viewModel);
        }

        // GET: AccountLedgers/Create
        public IActionResult Create()
        {
            ViewData["FiscalYearId"] = new SelectList(_fiscalYearData.GetFiscalYears(), "FiscalYearId", "YearDescription");

            return View();
        }

        // POST: AccountLedgers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AccountLedgerViewModel viewModel)
        {
            // Check for valid FiscalYearId
            if (_fiscalYearData.GetFiscalYearById(viewModel.FiscalYearId) == null)
                ModelState.AddModelError("FiscalYearId", $"Fiscal Year does not exist.");

            // Check for valid AccountId
            if (_accountData.GetAccountById(viewModel.AccountId) == null)
                ModelState.AddModelError("AccountId", $"Account ID does not exist.");

            if (ModelState.IsValid)
            {
                var accountLedger = new AccountLedger
                {
                    FiscalYearId = viewModel.FiscalYearId,
                    AccountId = viewModel.AccountId,
                    LedgerNo = viewModel.LedgerNo,
                    Ledger = viewModel.Ledger,
                    UserId = viewModel.UserId,
                    Remarks = viewModel.Remarks
                };

                try
                {
                    _accountLedgerData.AddAccountLedger(accountLedger);
                    _accountLedgerData.Save();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, $"ERROR: Unable to save data. Please review your input and try again.");
                    // TODO: Log this exception
                    ViewData["FiscalYearId"] = new SelectList(_fiscalYearData.GetFiscalYears(), "FiscalYearId", "YearDescription", viewModel.FiscalYearId);
                    return View(viewModel);
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["FiscalYearId"] = new SelectList(_fiscalYearData.GetFiscalYears(), "FiscalYearId", "YearDescription", viewModel.FiscalYearId);
            return View(viewModel);
        }
    }
}
