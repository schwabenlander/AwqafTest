using System.Collections.Generic;
using AwqafTest.Models;
using AwqafTest.Models.ViewModels;

namespace AwqafTest.Database
{
    public interface IAwqafDataService
    {
        // FISCAL_YEARS
        IEnumerable<FiscalYears> GetFiscalYears();
        FiscalYears GetFiscalYear(string year);
        FiscalYears GetFiscalYearById(int id);
        FiscalYears AddFiscalYear(FiscalYearViewModel newFiscalYear);
        FiscalYears UpdateFiscalYear(FiscalYearViewModel updatedFiscalYear);
        FiscalYears DeleteFiscalYear(int id);


        // ACCOUNTS

        // ACCOUNTS_LEDGERS

        // VOUCHERS
    }
}