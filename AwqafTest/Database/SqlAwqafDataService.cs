using System.Collections.Generic;
using System.Linq;
using AwqafTest.Models;
using AwqafTest.Models.ViewModels;

namespace AwqafTest.Database
{
    public class SqlAwqafDataService : IAwqafDataService
    {
        private readonly AwqafContext _database;

        public SqlAwqafDataService(AwqafContext database)
        {
            _database = database;
        }

        public IEnumerable<FiscalYears> GetFiscalYears()
        {
            return _database.FiscalYears.OrderBy(f => f.FiscalYearId);
        }

        public FiscalYears GetFiscalYear(string year)
        {
            return _database.FiscalYears.SingleOrDefault(f => f.YearDescription == year);
        }

        public FiscalYears GetFiscalYearById(int id)
        {
            return _database.FiscalYears.Find(id);
        }

        public FiscalYears AddFiscalYear(FiscalYearViewModel newFiscalYear)
        {
            throw new System.NotImplementedException();
        }

        public FiscalYears UpdateFiscalYear(FiscalYearViewModel updatedFiscalYear)
        {
            throw new System.NotImplementedException();
        }

        public FiscalYears DeleteFiscalYear(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}