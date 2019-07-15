using System.Collections.Generic;
using System.Linq;
using AwqafTest.Models;
using AwqafTest.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AwqafTest.Database
{
    public class FiscalYearSqlDataService : IFiscalYearDataService
    {
        private readonly AwqafDatabase _database;

        public FiscalYearSqlDataService(AwqafDatabase database)
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
            return _database.FiscalYears.Any() ? _database.FiscalYears.Max(f => f.FiscalYearId) : (byte)0;
        }

        public int Save()
        {
            return _database.SaveChanges();
        }
    }
}