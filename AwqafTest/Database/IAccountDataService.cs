using System.Collections.Generic;
using AwqafTest.Models;

namespace AwqafTest.Database
{
    public interface IAccountDataService
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccountById(int id);
        Account GetAccount(string account);
        int GetMaxAccountId();
        Account AddAccount(Account newAccount);
        int Save();
    }
}