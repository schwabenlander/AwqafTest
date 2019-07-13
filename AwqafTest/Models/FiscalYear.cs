using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AwqafTest.Models
{
    public partial class FiscalYear
    {
        public FiscalYear()
        {
            AccountsLedgers = new HashSet<AccountLedger>();
        }

        public byte FiscalYearId { get; set; }
        public string YearDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte? IsCurrent { get; set; }
        public byte? IsOpen { get; set; }

        public virtual ICollection<AccountLedger> AccountsLedgers { get; set; }
    }
}
