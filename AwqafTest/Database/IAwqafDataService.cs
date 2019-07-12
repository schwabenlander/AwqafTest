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
        FiscalYear GetFiscalYearById(byte id);
        FiscalYear AddFiscalYear(FiscalYear newFiscalYear);
        byte GetMaxFiscalYearId();
        int Save();

        // ACCOUNTS

        // ACCOUNTS_LEDGERS

        // VOUCHERS
    }
}