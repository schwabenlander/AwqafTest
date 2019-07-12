using System;
using System.Collections.Generic;

namespace AwqafTest.Models
{
    public partial class AccountsLedgers
    {
        public AccountsLedgers()
        {
            Vouchers = new HashSet<Vouchers>();
        }

        public byte FiscalYearId { get; set; }
        public int AccountId { get; set; }
        public int LedgerNo { get; set; }
        public string Ledger { get; set; }
        public DateTime? SystemDate { get; set; }
        public int? UserId { get; set; }
        public string Remarks { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual FiscalYears FiscalYear { get; set; }
        public virtual ICollection<Vouchers> Vouchers { get; set; }
    }
}
