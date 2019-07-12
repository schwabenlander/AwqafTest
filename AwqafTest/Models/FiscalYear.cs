using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AwqafTest.Models
{
    public partial class FiscalYear
    {
        public FiscalYear()
        {
            AccountsLedgers = new HashSet<AccountsLedger>();
        }

        public byte FiscalYearId { get; set; }

        public string YearDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public byte? IsCurrent { get; set; }

        public byte? IsOpen { get; set; }

        public virtual ICollection<AccountsLedger> AccountsLedgers { get; set; }
    }
}
