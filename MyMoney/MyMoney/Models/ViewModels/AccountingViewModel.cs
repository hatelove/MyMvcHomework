using MyMoney.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyMoney.Models.ViewModels
{
    public class AccountingViewModel
    {
        [Display(Name = "金額")]
        [DisplayFormat(DataFormatString ="{0:N0}")]
        public int Amount { get; internal set; }

        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; internal set; }

        [Display(Name ="備註")]
        public string Remark { get; internal set; }

        [Display(Name ="類別")]
        public AccountingType Type { get; internal set; }
    }
}