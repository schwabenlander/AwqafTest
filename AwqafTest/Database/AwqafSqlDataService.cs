using System.Collections.Generic;
using System.Linq;
using AwqafTest.Models;
using AwqafTest.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AwqafTest.Database
{
    public class AwqafSqlDataService : IAwqafDataService
    {
        private readonly AwqafContext _database;

        public AwqafSqlDataService(AwqafContext database)
        {
            _database = database;
        }

        public IEnumerable<FiscalYear> GetFiscalYears()
        {
            return _database.FiscalYears.OrderBy(f => f.FiscalYearId);
        }

        public FiscalYear GetFiscalYear(string year)
        {
            return _database.FiscalYears.SingleOrDefault(f => f.YearDescription == year);
        }

        public FiscalYear GetFiscalYearById(byte id)
        {
            return _database.FiscalYears.Find(id);
        }

        public FiscalYear AddFiscalYear(FiscalYear newFiscalYear)
        {
            _database.FiscalYears.Add(newFiscalYear);

            return newFiscalYear;
        }

        public byte GetMaxFiscalYearId()
        {
            return _database.FiscalYears.Max(f => f.FiscalYearId);
        }

        public int Save()
        {
            return _database.SaveChanges();
        }
    }
}