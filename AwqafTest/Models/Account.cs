using System;
using System.Collections.Generic;

namespace AwqafTest.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountsLedgers = new HashSet<AccountsLedger>();
        }

        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public short Level1 { get; set; }
        public short Level2 { get; set; }
        public short Level3 { get; set; }
        public short Level4 { get; set; }
        public DateTime? SystemDate { get; set; }
        public string Remarks { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<AccountsLedger> AccountsLedgers { get; set; }
    }
}
