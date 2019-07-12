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
            AccountsLedgers = new HashSet<AccountsLedger>();
        }

        [Required, Display(Name = "ID")]
        public byte FiscalYearId { get; set; }

        [Required, StringLength(4), Display(Name = "Year")]
        public string YearDescription { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Is Current?")]
        public byte? IsCurrent { get; set; }

        [Display(Name = "Is Open?")]
        public byte? IsOpen { get; set; }

        public virtual ICollection<AccountsLedger> AccountsLedgers { get; set; }
    }
}
