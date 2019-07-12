﻿using System;
using System.Collections.Generic;

namespace AwqafTest.Models
{
    public partial class Vouchers
    {
        public int VoucherId { get; set; }
        public DateTime? VoucherDate { get; set; }
        public byte? VoucherStatusId { get; set; }
        public decimal? VoucherTotal { get; set; }
        public byte FiscalYearId { get; set; }
        public int AccountId { get; set; }
        public int LedgerNo { get; set; }
        public string Remarks { get; set; }
        public DateTime? SystemDate { get; set; }
        public int? UserId { get; set; }

        public virtual AccountsLedgers AccountsLedgers { get; set; }
    }
}
