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
            var accounts = _accountData.GetAccounts();
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AccountViewModel viewModel)
        {
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
