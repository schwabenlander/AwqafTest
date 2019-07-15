using System.Collections.Generic;
using System.Linq;
using AwqafTest.Models;

namespace AwqafTest.Database
{
    public class AccountDataService : IAccountDataService
    {
        private readonly AwqafDatabase _database;

        public AccountDataService(AwqafDatabase database)
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
            return _database.Accounts.SingleOrDefault(a => a.AccountName == account);
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