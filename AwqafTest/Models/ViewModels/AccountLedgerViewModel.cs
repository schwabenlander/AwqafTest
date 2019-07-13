using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AwqafTest.Models.ViewModels
{
    public class AccountLedgerViewModel
    {
        [Required, Display(Name = "Fiscal Year ID"), Range(1, byte.MaxValue)]
        public byte FiscalYearId { get; set; }

        [Required, Display(Name = "Account ID"), Range(1, int.MaxValue)]
        public int AccountId { get; set; }

        [Required, Display(Name = "Ledger Number"), Range(1, int.MaxValue)]
        public int LedgerNo { get; set; }

        [Required, Display(Name = "Ledger"), StringLength(250)]
        public string Ledger { get; set; }

        [Display(Name = "Remarks"), StringLength(300)]
        public string Remarks { get; set; }

        [Display(Name = "User ID"), Range(1, int.MaxValue)]
        public int? UserId { get; set; }

        [HiddenInput, Display(Name = "Date Created"), DataType(DataType.Date)]
        public DateTime? SystemDate { get; set; }

        [Display(Name = "Account")]
        public Account Account { get; set; }

        [Display(Name = "Fiscal Year")]
        public FiscalYear FiscalYear { get; set; }
    }
}