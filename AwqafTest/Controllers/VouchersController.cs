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
    public class VouchersController : Controller
    {
        private readonly IVoucherDataService _voucherData;

        public VouchersController(IVoucherDataService voucherData)
        {
            _voucherData = voucherData;
        }

        // GET: Vouchers
        public IActionResult Index()
        {
            var vouchers = _voucherData.GetVouchers();
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
            throw new NotImplementedException();
//            ViewData["FiscalYearId"] = new SelectList(_context.AccountsLedgers, "FiscalYearId", "Ledger");
//            return View();
        }

        // POST: Vouchers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VoucherViewModel viewModel)
        {
            throw new NotImplementedException();

//            if (ModelState.IsValid)
//            {
//                _context.Add(voucher);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["FiscalYearId"] = new SelectList(_context.AccountsLedgers, "FiscalYearId", "Ledger", voucher.FiscalYearId);
//            return View(voucher);
        }
    }
}
