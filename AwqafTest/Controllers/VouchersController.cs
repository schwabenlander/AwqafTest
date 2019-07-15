using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AwqafTest.Database;
using AwqafTest.Models;
using AwqafTest.Models.ViewModels;

namespace AwqafTest.Controllers
{
    public class VouchersController : Controller
    {
        private readonly IVoucherDataService _voucherData;
        private readonly IFiscalYearDataService _fiscalYearData;
        private readonly IAccountDataService _accountData;
        private readonly IAccountLedgerDataService _accountLedgerData;

        public VouchersController(IVoucherDataService voucherData, 
                                  IFiscalYearDataService fiscalYearData, 
                                  IAccountDataService accountData, 
                                  IAccountLedgerDataService accountLedgerData)
        {
            _voucherData = voucherData;
            _fiscalYearData = fiscalYearData;
            _accountData = accountData;
            _accountLedgerData = accountLedgerData;
        }

        // GET: Vouchers
        public IActionResult Index()
        {
            // TODO: Add paging of Vouchers
            // Return only the first 100 results until paging can be implemented
            var vouchers = _voucherData.GetVouchers().Take(100);
            var viewModel = new List<VoucherViewModel>();

            foreach (var voucher in vouchers)
            {
                viewModel.Add(new VoucherViewModel
                {
                    VoucherId = voucher.VoucherId,
                    VoucherDate = voucher.VoucherDate,
                    VoucherStatusId = voucher.VoucherStatusId,
                    VoucherTotal = voucher.VoucherTotal,
                    FiscalYearId = voucher.FiscalYearId,
                    AccountId = voucher.AccountId,
                    LedgerNo = voucher.LedgerNo,
                    Remarks = voucher.Remarks,
                    SystemDate = voucher.SystemDate,
                    UserId = voucher.UserId
                });
            }

            return View(viewModel);
        }

        // GET: Vouchers/Create
        public IActionResult Create()
        {
            ViewData["NextId"] = _voucherData.GetMaxVoucherId() + 1;
            ViewData["FiscalYearId"] = new SelectList(_fiscalYearData.GetFiscalYears(), "FiscalYearId", "YearDescription");
            return View();
        }

        // POST: Vouchers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VoucherViewModel viewModel)
        {
            // Check for valid FiscalYearId
            if (_fiscalYearData.GetFiscalYearById(viewModel.FiscalYearId) == null)
                ModelState.AddModelError("FiscalYearId", $"Fiscal Year does not exist.");

            // Check for valid AccountId
            if (_accountData.GetAccountById(viewModel.AccountId) == null)
                ModelState.AddModelError("AccountId", $"Account ID does not exist.");
            
            // Check for valid Ledger: (FISCAL_YEAR_ID, ACCOUNT_ID, LEDGER_NO)
            if (_accountLedgerData
                    .GetAccountLedger(viewModel.FiscalYearId, viewModel.AccountId, viewModel.LedgerNo) == null)
                ModelState.AddModelError("LedgerNo", $"Ledger does not exist.");

            if (ModelState.IsValid)
            {
                var voucher = new Voucher
                {
                    VoucherId = viewModel.VoucherId,
                    VoucherDate = viewModel.VoucherDate,
                    VoucherStatusId = viewModel.VoucherStatusId,
                    VoucherTotal = viewModel.VoucherTotal,
                    FiscalYearId = viewModel.FiscalYearId,
                    AccountId = viewModel.AccountId,
                    LedgerNo = viewModel.LedgerNo,
                    Remarks = viewModel.Remarks,
                    SystemDate = viewModel.SystemDate,
                    UserId = viewModel.UserId
                };

                try
                {
                    _voucherData.AddVoucher(voucher);
                    _voucherData.Save();
                }
                catch (Exception e)
                {
                    // TODO: Log this exception
                    ModelState.AddModelError(string.Empty, $"ERROR: Unable to save data. Please review your input and try again.");
                    
                    ViewData["FiscalYearId"] = new SelectList(_fiscalYearData.GetFiscalYears(), "FiscalYearId", "YearDescription", viewModel.FiscalYearId);
                    return View(viewModel);
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["NextId"] = _voucherData.GetMaxVoucherId() + 1;
            ViewData["FiscalYearId"] = new SelectList(_fiscalYearData.GetFiscalYears(), "FiscalYearId", "YearDescription", viewModel.FiscalYearId);
            return View(viewModel);
        }
    }
}
