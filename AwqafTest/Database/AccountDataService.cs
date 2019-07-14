using System.Collections.Generic;
using System.Linq;
using AwqafTest.Models;

namespace AwqafTest.Database
{
    public class AccountDataService : IAccountDataService
    {
        private readonly AwqafContext _database;

        public AccountDataService(AwqafContext database)
        {
            _database = database;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _database.Accounts.OrderBy(a => a.AccountId);
        }

        public Account GetAccountById(int id)
        {
            return _database.Accounts.Find(id);
        }

        public Account GetAccount(string account)
        {
            return _database.Accounts.SingleOrDefault(a => a.AccountNumber == account);
        }

        public int GetMaxAccountId()
        {
            return _database.Accounts.Any() ? _database.Accounts.Max(a => a.AccountId) : 0;
        }

        public Account AddAccount(Account newAccount)
        {
            _database.Accounts.Add(newAccount);

            return newAccount;
        }

        public int Save()
        {
            return _database.SaveChanges();
        }
    }
}