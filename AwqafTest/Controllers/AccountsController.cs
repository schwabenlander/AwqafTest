﻿using System;
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
    public class AccountsController : Controller
    {
        private readonly IAccountDataService _accountData;

        public AccountsController(IAccountDataService accountData)
        {
            _accountData = accountData;
        }

        // GET: Accounts
        public IActionResult Index()
        {
            // TODO: Add paging of Accounts
            var accounts = _accountData.GetAccounts().Take(100);
            var viewModel = new List<AccountViewModel>();

            foreach (var account in accounts)
            {
                viewModel.Add(new AccountViewModel
                {
                    AccountId = account.AccountId,
                    AccountNumber = account.AccountNumber,
                    Level1 = account.Level1,
                    Level2 = account.Level2,
                    Level3 = account.Level3,
                    Level4 = account.Level4,
                    UserId = account.UserId,
                    SystemDate = account.SystemDate
                });
            }

            return View(viewModel);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            TempData["NextId"] = _accountData.GetMaxAccountId() + 1;

            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AccountViewModel viewModel)
        {
            // Check to see if FISCAL_YEAR_ID already exists
            if (_accountData.GetAccountById(viewModel.AccountId) != null)
                ModelState.AddModelError("AccountId", $"Account ID ({viewModel.AccountId}) already exists.");

            if (ModelState.IsValid)
            {
                var account = new Account
                {
                    AccountId = viewModel.AccountId,
                    AccountNumber = viewModel.AccountNumber,
                    Level1 = viewModel.Level1,
                    Level2 = viewModel.Level2,
                    Level3 = viewModel.Level3,
                    Level4 = viewModel.Level4,
                    Remarks = viewModel.Remarks,
                    UserId = viewModel.UserId
                };

                _accountData.AddAccount(account);
                _accountData.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
    }
}
