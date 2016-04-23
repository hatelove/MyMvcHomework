using MyMoney.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyMoney.Models.ViewModels
{
    public class AccountingViewModel
    {
        [Display(Name = "金額")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Required]
        public int Amount { get; set; }

        [Display(Name = "日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        [Required]
        public string Remark { get; set; }

        [Display(Name = "類別")]
        [Required]
        public AccountingType Type { get; set; }
    }
}