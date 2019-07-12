﻿using System.Collections.Generic;
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

        public FiscalYear GetFiscalYearById(int id)
        {
            return _database.FiscalYears.Find(id);
        }

        public FiscalYear AddFiscalYear(FiscalYear newFiscalYear)
        {
            _database.FiscalYears.Add(newFiscalYear);

            return newFiscalYear;
        }

        public FiscalYear UpdateFiscalYear(FiscalYear updatedFiscalYear)
        {
            var fiscalYear = _database.FiscalYears.Attach(updatedFiscalYear);
            fiscalYear.State = EntityState.Modified;

            return updatedFiscalYear;
        }

        public FiscalYear DeleteFiscalYear(int id)
        {
            var fiscalYear = GetFiscalYearById(id);

            if (fiscalYear != null)
                _database.FiscalYears.Remove(fiscalYear);

            return fiscalYear;
        }

        public int Commit()
        {
            return _database.SaveChanges();
        }
    }
}