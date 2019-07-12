using System;
using System.Collections.Generic;

namespace AwqafTest.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            AccountsLedgers = new HashSet<AccountsLedgers>();
        }

        public int AccountId { get; set; }
        public string Account { get; set; }
        public short Level1 { get; set; }
        public short Level2 { get; set; }
        public short Level3 { get; set; }
        public short Level4 { get; set; }
        public DateTime? SystemDate { get; set; }
        public int? UserId { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<AccountsLedgers> AccountsLedgers { get; set; }
    }
}
