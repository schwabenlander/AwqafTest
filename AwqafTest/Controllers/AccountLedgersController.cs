using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AwqafTest.Database;
using AwqafTest.Models;

namespace AwqafTest.Controllers
{
    public class AccountLedgersController : Controller
    {
        private readonly AwqafContext _context;

        public AccountLedgersController(AwqafContext context)
        {
            _context = context;
        }

        // GET: AccountLedgers
        public async Task<IActionResult> Index()
        {
            var awqafContext = _context.AccountsLedgers.Include(a => a.Account).Include(a => a.FiscalYear);
            return View(await awqafContext.ToListAsync());
        }

        // GET: AccountLedgers/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountLedger = await _context.AccountsLedgers
                .Include(a => a.Account)
                .Include(a => a.FiscalYear)
                .FirstOrDefaultAsync(m => m.FiscalYearId == id);
            if (accountLedger == null)
            {
                return NotFound();
            }

            return View(accountLedger);
        }

        // GET: AccountLedgers/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountNumber");
            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "YearDescription");
            return View();
        }

        // POST: AccountLedgers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiscalYearId,AccountId,LedgerNo,Ledger,SystemDate,Remarks,UserId")] AccountLedger accountLedger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountLedger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountNumber", accountLedger.AccountId);
            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "YearDescription", accountLedger.FiscalYearId);
            return View(accountLedger);
        }

        // GET: AccountLedgers/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountLedger = await _context.AccountsLedgers.FindAsync(id);
            if (accountLedger == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountNumber", accountLedger.AccountId);
            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "YearDescription", accountLedger.FiscalYearId);
            return View(accountLedger);
        }

        // POST: AccountLedgers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("FiscalYearId,AccountId,LedgerNo,Ledger,SystemDate,Remarks,UserId")] AccountLedger accountLedger)
        {
            if (id != accountLedger.FiscalYearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountLedger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountLedgerExists(accountLedger.FiscalYearId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountNumber", accountLedger.AccountId);
            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "YearDescription", accountLedger.FiscalYearId);
            return View(accountLedger);
        }

        // GET: AccountLedgers/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountLedger = await _context.AccountsLedgers
                .Include(a => a.Account)
                .Include(a => a.FiscalYear)
                .FirstOrDefaultAsync(m => m.FiscalYearId == id);
            if (accountLedger == null)
            {
                return NotFound();
            }

            return View(accountLedger);
        }

        // POST: AccountLedgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var accountLedger = await _context.AccountsLedgers.FindAsync(id);
            _context.AccountsLedgers.Remove(accountLedger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountLedgerExists(byte id)
        {
            return _context.AccountsLedgers.Any(e => e.FiscalYearId == id);
        }
    }
}
