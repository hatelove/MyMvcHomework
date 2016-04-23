using MyMoney.Models.CustomValidationAttributes;
using MyMoney.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyMoney.Models.ViewModels
{
    public class AccountingViewModel
    {
        [Display(Name = "金額")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Range(0, int.MaxValue, ErrorMessage = "{0}需為正整數")]
        [Required]
        public int Amount { get; set; }

        [Display(Name = "日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Required]
        [DateBeforeToday(ErrorMessage = "{0}不可大於今天")]
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        [DataType(DataType.MultilineText)]
        [Required]
        [TextAreaStringLength(3, ErrorMessage = "{0}長度不得超過{1}")]
        public string Remark { get; set; }

        [Display(Name = "類別")]
        [Required]
        public AccountingType Type { get; set; }
    }
}