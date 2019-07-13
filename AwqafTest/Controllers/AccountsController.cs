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
                    UserId = account.UserId
                });
            }

            return View(viewModel);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AccountId,AccountNumber,Level1,Level2,Level3,Level4,SystemDate,Remarks,UserId")] Account account)
        {
            throw new NotImplementedException();
        }
    }
}
