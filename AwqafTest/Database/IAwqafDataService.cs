using System.Collections.Generic;
using AwqafTest.Models;
using AwqafTest.Models.ViewModels;

namespace AwqafTest.Database
{
    public interface IAwqafDataService
    {
        // FISCAL_YEARS
        IEnumerable<FiscalYear> GetFiscalYears();
        FiscalYear GetFiscalYear(string year);
        FiscalYear GetFiscalYearById(int id);
        FiscalYear AddFiscalYear(FiscalYear newFiscalYear);
        FiscalYear UpdateFiscalYear(FiscalYear updatedFiscalYear);
        FiscalYear DeleteFiscalYear(int id);
        int Save();

        // ACCOUNTS

        // ACCOUNTS_LEDGERS

        // VOUCHERS
    }
}