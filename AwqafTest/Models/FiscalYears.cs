using System;
using System.Collections.Generic;

namespace AwqafTest.Models
{
    public partial class FiscalYears
    {
        public FiscalYears()
        {
            AccountsLedgers = new HashSet<AccountsLedgers>();
        }

        public byte FiscalYearId { get; set; }
        public string YearDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte? IsCurrent { get; set; }
        public byte? IsOpen { get; set; }

        public virtual ICollection<AccountsLedgers> AccountsLedgers { get; set; }
    }
}
