using System.Collections.Generic;
using System.Linq;
using AwqafTest.Models;

namespace AwqafTest.Database
{
    public class AccountLedgerDataService : IAccountLedgerDataService
    {
        private readonly AwqafContext _database;

        public AccountLedgerDataService(AwqafContext database)
        {
            _database = database;
        }

        public IEnumerable<AccountLedger> GetAccountLedgers()
        {
            return _database.AccountsLedgers
                .OrderBy(a => a.FiscalYearId)
                .ThenBy(a => a.AccountId)
                .ThenBy(a => a.LedgerNo);
        }

        public AccountLedger GetAccountLedger(byte fiscalYearId, int accountId, int ledgerNo)
        {
            return _database.AccountsLedgers
                .SingleOrDefault(a => a.FiscalYearId == fiscalYearId &&
                                      a.AccountId == accountId &&
                                      a.LedgerNo == ledgerNo);
        }

        public AccountLedger AddAccount(AccountLedger newAccountLedger)
        {
            _database.AccountsLedgers.Add(newAccountLedger);

            return newAccountLedger;
        }

        public int Save()
        {
            return _database.SaveChanges();
        }
    }
}