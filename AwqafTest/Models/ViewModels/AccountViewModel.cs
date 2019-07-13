using System;
using System.ComponentModel.DataAnnotations;

namespace AwqafTest.Models.ViewModels
{
    public class AccountViewModel
    {
        [Required, Display(Name = "Account ID"), Range(1, int.MaxValue)]
        public int AccountId { get; set; }

        [Required, Display(Name = "Account Number"), StringLength(100)]
        public string AccountNumber { get; set; }

        [Required, Display(Name = "Level 1"), Range(0, short.MaxValue)]
        public short Level1 { get; set; }

        [Required, Display(Name = "Level 2"), Range(0, short.MaxValue)]
        public short Level2 { get; set; }

        [Required, Display(Name = "Level 3"), Range(0, short.MaxValue)]
        public short Level3 { get; set; }

        [Required, Display(Name = "Level 4"), Range(0, short.MaxValue)]
        public short Level4 { get; set; }

        [Display(Name = "Remarks"), StringLength(300)]
        public string Remarks { get; set; }

        [Display(Name = "User ID"), Range(1, int.MaxValue)]
        public int? UserId { get; set; }
    }
}