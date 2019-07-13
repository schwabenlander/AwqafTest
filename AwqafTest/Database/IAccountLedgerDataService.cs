using System.Collections.Generic;
using AwqafTest.Models;

namespace AwqafTest.Database
{
    public interface IAccountLedgerDataService
    {
        IEnumerable<AccountLedger> GetAccountLedgers();
        AccountLedger GetAccountLedger(byte fiscalYearId, int accountId, int ledgerNo);
        AccountLedger AddAccountLedger(AccountLedger newAccountLedger);
        int Save();
    }
}